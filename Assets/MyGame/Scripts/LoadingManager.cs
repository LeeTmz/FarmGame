using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private Slider sLoading;
    [SerializeField] private Image bg;
    [SerializeField] private TextMeshProUGUI textPorcent;


    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }
    private IEnumerator LoadSceneAsync() 
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while (operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f) * 100;
            sLoading.value = progress;
            textPorcent.text = progress.ToString() + "%";

            yield return null;
        }


    }
}
