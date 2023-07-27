using UnityEngine;
using Mirror;
using Cinemachine;

/// <summary>
/// Handles the lobby player object when a player joins the lobby.
/// </summary>
public class NetworkLobbyPlayer : NetworkBehaviour
{
    private readonly NetworkManagerEden NetMng = NetworkManagerEden.Singleton;

    public bool isLeader = false;
    public string DisplayName = "Loading...";

    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;

    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private Transform cameraRoot;

    private NetworkIdentity playerIdentity = null;

    public override void OnStartClient()
    {
        playerIdentity = GetComponent<NetworkIdentity>();

        virtualCam.enabled = true;
        virtualCam.Follow = cameraRoot;

        LobbyUI.singleton.SpawnSlot(playerIdentity.netId, DisplayName);
        NetMng.LobbyPlayers.Add(this);
    }

    public override void OnStopClient()
    {
        LobbyUI.singleton.RemoveSlot(playerIdentity.netId);
        NetMng.LobbyPlayers.Remove(this);
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateReadyStatus();

    private void UpdateReadyStatus()
    {
        if (isLocalPlayer)
        {
            LobbyUI.singleton.SetReadyStatus(playerIdentity.netId, IsReady);
        }
    }
}
