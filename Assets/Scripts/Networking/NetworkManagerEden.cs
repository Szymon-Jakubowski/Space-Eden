using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerEden : NetworkManager
{
    // Overrides the base singleton so we don't
    // have to cast to this type everywhere.
    public static new NetworkManagerEden singleton { get; private set; }
    
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
    [SerializeField] 
    private GameObject lobbyPlayerPrefab = null;
    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Awake()
    {
        base.Awake();
        singleton = this;
    }


}
