using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuitToTitleManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        if (!PhotonNetwork.OfflineMode)
        {
            PhotonNetwork.Disconnect();
        } else
        {
            GameManager.Instance.QuitToTitle();
        }
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        GameManager.Instance.QuitToTitle();
    }
}
