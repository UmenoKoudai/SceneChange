using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] SceneName _sceneName;
    private void Awake()
    {
        GetComponentInChildren<Text>().text = _sceneName.NextName;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(_sceneName.NextName);
    }
}
