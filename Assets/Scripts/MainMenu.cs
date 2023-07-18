using kcp2k;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
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
        if (nameInput.text.Length == 0)
        {
            nameInput.text = "Player";
        }

        if (ushort.TryParse(portAdressHost.text, out var port))
        {
            NetworkManager.singleton.networkAddress = ipAdressHost.text;
            NetworkManager.singleton.gameObject.GetComponent<KcpTransport>().Port = port;
            NetworkManager.singleton.playerPrefab.name = nameInput.text;

            NetworkManager.singleton.StartHost();
        }
        else
        {
            Debug.Log("Invalid port input");
        }
    }

    public void StartClient()
    {
        if (nameInput.text.Length == 0)
        {
            nameInput.text = "Player";
        }

        if (ushort.TryParse(portAdressClient.text, out var port))
        {
            NetworkManager.singleton.networkAddress = ipAdressClient.text;
            NetworkManager.singleton.gameObject.GetComponent<KcpTransport>().Port = port;
            NetworkManager.singleton.playerPrefab.name = nameInput.text;

            NetworkManager.singleton.StartClient();
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
