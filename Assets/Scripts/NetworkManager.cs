using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PhotonView PV;
    [SerializeField]GameObject parent;
    private void Awake()
    {
        Screen.SetResolution(960, 540, false);  
        PhotonNetwork.GameVersion= "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PV.RPC("planetsStart", RpcTarget.All); //RPC 함수 호출 
        }
            
    }
    private void Update()
    {
        if(PhotonNetwork.IsMasterClient) 
        {
            PV.RPC("planetsUpdate", RpcTarget.All); //RPC 함수 호출 

        }

    }
    public override void OnConnectedToMaster() => PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { }, null);
    public override void OnJoinedRoom()
    {
        //StartCoroutine(wait());

    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);

        //PhotonNetwork.Instantiate("Sun", new Vector3(0, 0, 0), Quaternion.identity).transform.SetParent(parent.transform);
        //PhotonNetwork.Instantiate("Mercury", new Vector3(0, 0, 13), Quaternion.identity).transform.SetParent(parent.transform);
    }
    
}
