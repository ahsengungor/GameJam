using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TMPSequenceDisplay : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    private void Start()
    {
        StartCoroutine(ShowTextsAndLoadScene());
    }

    IEnumerator ShowTextsAndLoadScene()
    {
        // İlk TMP'yi göster, diğerini kapat
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        // İlk TMP'yi kapat, ikincisini göster
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        // Sahneyi yükle
        SceneManager.LoadScene("MainMenu");
    }
}