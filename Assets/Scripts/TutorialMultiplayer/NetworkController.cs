using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace TutorialMultiplayer
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to the " + PhotonNetwork.CloudRegion + " server!");
        }
    }
}

