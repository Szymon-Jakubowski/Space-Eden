using Mirror;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerEden : NetworkManager
{
    // Overrides the base singleton so we don't
    // have to cast to this type everywhere.
    public static NetworkManagerEden Singleton { get; private set; }
    
    [Header("=== Scenes ===")]
    [Scene] 
    [SerializeField] 
    private string menuScene = string.Empty;
    [Scene] 
    [SerializeField] 
    private string lobbyScene = string.Empty;
    [Scene] 
    [SerializeField] 
    private string gameScene = string.Empty;

    [Header("=== Lobby ===")]
    public GameObject lobbyPlayerPrefab = null;
    public List<NetworkLobbyPlayer> LobbyPlayers { get; } = new List<NetworkLobbyPlayer>();

    [Header("=== Other ===")]
    [SerializeField] private int minPlayers = 2;

    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Awake()
    {
        base.Awake();
        Singleton = this;
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if(SceneManager.GetActiveScene().path == lobbyScene)
        {
            var isLeader = LobbyPlayers.Count == 0;

            var lobbyPlayerInstance = Instantiate(lobbyPlayerPrefab);
            var lobbyPlayer = lobbyPlayerInstance.GetComponent<NetworkLobbyPlayer>();
            lobbyPlayer.isLeader = isLeader;

            NetworkServer.AddPlayerForConnection(conn, lobbyPlayerInstance);
        }
    }
}
