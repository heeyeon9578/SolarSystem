using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using Photon.Pun;

public class Planet :MonoBehaviourPun, IPunObservable
{

    [SerializeField] protected GameObject sunPrefab; //������ �༺ 
    [SerializeField] protected GameObject planetPrefab; //�༺

    [SerializeField] protected float rotateSunSpeed; //�����ӵ�
    [SerializeField] protected float rotateThisSpeed; //�����ӵ�

    [SerializeField] protected float planetSize; //�༺ ������
    [SerializeField] protected float zPosition; //�༺ ���� �� z�� ��ġ
    Vector3 remotePos; Vector3 remoteScale; Quaternion remoteRot;
    public GameObject SunPrefab   // property
    {
        get { return sunPrefab; }   // get method
        set { sunPrefab = value; }  // set method
    }
    public GameObject PlanetPrefab   // property
    {
        get { return planetPrefab; }   // get method
        set { planetPrefab = value; }  // set method
    }
    public float RotateSunSpeed   // property
    {
        get { return rotateSunSpeed; }   // get method
        set { rotateSunSpeed = value; }  // set method
    }
    public float RotateThisSpeed   // property
    {
        get { return rotateThisSpeed; }   // get method
        set { rotateThisSpeed = value; }  // set method
    }
    public float PlanetSize   // property
    {
        get { return planetSize; }   // get method
        set { planetSize = value; }  // set method
    }

    public float ZPosition   // property
    {
        get { return zPosition; }   // get method
        set { zPosition = value; }  // set method
    }
    public void Update()
    {

        if (false == photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, remotePos, 10 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, remoteRot, 10 * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, remoteScale, 10 * Time.deltaTime);
            return;
        }
    }
    public void planetStart()
    {
        setPosition();
        setSize();
    }
    public void planetUpdate()
    {
        RotateSun();
        RotateThis();
    }
    //����
    public void RotateSun()
    {
       
        transform.RotateAround(SunPrefab.transform.position, SunPrefab.transform.up, rotateSunSpeed * Time.deltaTime);
    }
    //����
    public void RotateThis()
    {
      
        transform.RotateAround(PlanetPrefab.transform.position, PlanetPrefab.transform.up, rotateThisSpeed * Time.deltaTime);

    }

    public void setPosition()
    {
        PlanetPrefab.transform.localPosition = new Vector3(0,0,zPosition);
    }
    public void setSize()
    {
        PlanetPrefab.transform.localScale = new Vector3(planetSize, planetSize, planetSize); ;
    }
    //�����͸� ��Ʈ��ũ ����� ���� ������ �ް� �ϴ� �ݹ� �Լ�
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            remotePos = (Vector3)stream.ReceiveNext();
            remoteRot = (Quaternion)stream.ReceiveNext();
            remoteScale = (Vector3)stream.ReceiveNext();
        }
    }
}
