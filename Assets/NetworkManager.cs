using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Screen.SetResolution(960, 540, false);  
        PhotonNetwork.GameVersion= "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { }, null);
    public override void OnJoinedRoom()
    {
       
    }
}
