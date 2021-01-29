﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delay = 4f;

    int currSceneIdx;

    // Start is called before the first frame update
    void Start()
    {
        currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        if (currSceneIdx == 0)
        {
            StartCoroutine(LoadDelay());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(delay);
        LoadNextScene();
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currSceneIdx + 1);
    }
}
