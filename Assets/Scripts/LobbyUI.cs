using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyUI : NetworkBehaviour
{
    public static LobbyUI singleton { get; private set; }
    public static NetworkManagerEden NetMng = NetworkManagerEden.Singleton;

    public GameObject LobbyPlayerUIPrefab = null;

    [SerializeField]
    private Transform PlayerSlots = null;
    [SerializeField]
    private string playerNameFieldName = "PlayerName";
    [SerializeField]
    private string readyStatusFieldName = "ReadyStatus";
    
    private void Awake()
    {
        singleton = this;
    }

    public void SpawnSlot(uint playerId, string displayName)
    {
        var slot = Instantiate(LobbyPlayerUIPrefab, PlayerSlots);
        slot.name = playerId.ToString();
        slot.transform.Find(playerNameFieldName).GetComponent<TMP_Text>().text = displayName;
        slot.transform.Find(readyStatusFieldName).GetComponent<TMP_Text>().text = "<color=red>Not Ready</color>";
    }
    
    public void SetReadyStatus(uint playerId, bool isReady)
    {
        PlayerSlots.transform.Find(playerId.ToString())
            .Find(readyStatusFieldName).GetComponent<TMP_Text>().text = isReady ? "<color=green>Ready</color>" : "<color=red>Not Ready</color>";
    }
    
    public void RemoveSlot(uint playerId)
    {
        var slot = PlayerSlots.transform.Find(playerId.ToString()).gameObject;

        Destroy(slot);
    }
}
