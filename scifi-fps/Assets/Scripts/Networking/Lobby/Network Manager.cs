using Photon.Pun;
using UnityEngine;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();   
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
    }
}
