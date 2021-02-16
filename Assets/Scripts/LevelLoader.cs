using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delay = 4f;

    [Header("Fade Out")]
    [SerializeField] GameObject fadeOut;
    [SerializeField] float fadeLoadDifference;
    [SerializeField] float fadeOutTime;

    int currSceneIdx;

    // Start is called before the first frame update
    void Start()
    {
        currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        if (currSceneIdx == 0)
        {
            StartCoroutine(LoadDelay());
            StartCoroutine(FadeDelay());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // For Splash Screen only
    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(delay);
        LoadNextScene();
    }

    public IEnumerator LoadNextScene()
    {
        Instantiate(fadeOut, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadScene(currSceneIdx + 1);
    }

    // For Splash Screen only
    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(delay - fadeLoadDifference);
        Instantiate(fadeOut, transform.position, Quaternion.identity);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void LoadNextSceneWrapper()
    {
        StartCoroutine(LoadNextScene());
    }
}
