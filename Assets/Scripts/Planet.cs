using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using Photon.Pun;

public class Planet :MonoBehaviourPun, IPunObservable
{

    [SerializeField] protected GameObject sunPrefab; //공전할 행성 
    [SerializeField] protected GameObject planetPrefab; //행성

    [SerializeField] protected float rotateSunSpeed; //공전속도
    [SerializeField] protected float rotateThisSpeed; //자전속도

    [SerializeField] protected float planetSize; //행성 사이즈
    [SerializeField] protected float zPosition; //행성 생성 시 z축 위치
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
    //공전
    public void RotateSun()
    {
       
        transform.RotateAround(SunPrefab.transform.position, SunPrefab.transform.up, rotateSunSpeed * Time.deltaTime);
    }
    //자전
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
    //데이터를 네트워크 사용자 간에 보내고 받게 하는 콜백 함수
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
