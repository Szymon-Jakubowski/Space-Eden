using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupScene : MonoBehaviour
{
    [Scene] [SerializeField]
    private string menuSceneName = string.Empty;

    private void Start()
    {
        SceneManager.LoadSceneAsync(menuSceneName);
    }
}
