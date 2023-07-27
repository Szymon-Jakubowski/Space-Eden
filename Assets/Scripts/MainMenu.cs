using kcp2k;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private readonly NetworkManagerEden NetMng = NetworkManagerEden.Singleton;

    [SerializeField]
    private GameObject hostPanel;
    [SerializeField]
    private GameObject joinPanel;
    [SerializeField]
    private TMP_InputField nameInput;

    [SerializeField]
    private TMP_InputField ipAdressHost;
    [SerializeField]
    private TMP_InputField ipAdressClient;
    [SerializeField]
    private TMP_InputField portAdressHost;
    [SerializeField]
    private TMP_InputField portAdressClient;

    public void Host()
    {
        hostPanel.SetActive(true);
    }

    public void Join()
    {
        joinPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartHost()
    {
        if (string.IsNullOrEmpty(nameInput.text)) nameInput.text = "Player";
        if (string.IsNullOrEmpty(ipAdressHost.text)) ipAdressHost.text = "localhost";
        if (string.IsNullOrEmpty(portAdressHost.text)) portAdressHost.text = "7777";

        if (ushort.TryParse(portAdressHost.text, out var port))
        {
            NetMng.networkAddress = ipAdressHost.text;
            NetMng.gameObject.GetComponent<KcpTransport>().Port = port;
            NetMng.lobbyPlayerPrefab.GetComponent<NetworkLobbyPlayer>().DisplayName = nameInput.text;

            NetMng.StartHost();
        }
        else
        {
            Debug.Log("Invalid port input");
        }
    }

    public void StartClient()
    {
        if (string.IsNullOrEmpty(nameInput.text)) nameInput.text = "Player";
        if (string.IsNullOrEmpty(ipAdressHost.text)) ipAdressHost.text = "localhost";
        if (string.IsNullOrEmpty(portAdressHost.text)) portAdressHost.text = "7777";

        if (ushort.TryParse(portAdressClient.text, out var port))
        {
            NetMng.networkAddress = ipAdressClient.text;
            NetMng.gameObject.GetComponent<KcpTransport>().Port = port;
            NetMng.lobbyPlayerPrefab.GetComponent<NetworkLobbyPlayer>().DisplayName = nameInput.text;

            NetMng.StartClient();
        }
        else
        {
            Debug.Log("Invalid port input");
        }
    }

    public void ClosePanel()
    {
        hostPanel.SetActive(false);
        joinPanel.SetActive(false);
    }
}
