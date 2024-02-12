using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

}