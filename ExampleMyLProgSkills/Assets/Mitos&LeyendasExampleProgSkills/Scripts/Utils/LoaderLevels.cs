using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoaderLevels : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider sldLoader;
    public Text sldTextPerc;


    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
        float progess = 0;

        loadingScreen.SetActive(true);

        while (!loadingOperation.isDone)
        {
            progess = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            sldLoader.value = progess;
            sldTextPerc.text = sldLoader.value + " %";
            Debug.Log(progess);
            yield return null;
        }
    }

    public void quitApp()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
