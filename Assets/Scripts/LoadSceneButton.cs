using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneName; // Inspector'dan ayarlayabileceğiniz sahne ismi

    public void LoadTargetScene()
    {
        // Sahne ismi boş değilse yükle
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not specified!");
        }
    }
}