using Cinemachine;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCameraHandler : NetworkBehaviour
{
    [SerializeField] private GameObject virtualCamera;

    public override void OnStartClient()
    {
        if(isLocalPlayer)
        {
            var virtualCameraObject = Instantiate(virtualCamera);
            //irtualCameraObject.GetComponent<CinemachineVirtualCamera>().Follow = ;
        }
    }
}
