using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public GameObject MenuScreen;
    public Slider slider;
    public void QuitApp() {

        Application.Quit();

    }

    public void LoadLevel(int sceneID) {
        Time.timeScale = 1;
        StartCoroutine(LoadAsynchronously(sceneID));

    }
    IEnumerator LoadAsynchronously(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        MenuScreen.SetActive(false);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }

    }
    public void ReloadScene() {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);


        }
}
