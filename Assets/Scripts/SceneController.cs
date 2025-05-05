using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // AAA sahnesini yükler
    public void LoadScene_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // XXX sahnesini yükler
    public void LoadScene_XXX()
    {
        SceneManager.LoadScene("xxx");
    }

    // Oyunu tamamen kapatır
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Editörde deneme yaparken oyunu durdurur
#else
            Application.Quit(); // Build aldıktan sonra oyunu kapatır
#endif
    }
}