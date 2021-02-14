using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [Header("SFX")]
    [SerializeField] AudioClip pauseSFX;
    [SerializeField] [Range(0f, 1f)] float pauseVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandlePause();
    }

    private void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        AudioSource.PlayClipAtPoint(pauseSFX, Camera.main.transform.position, pauseVolume);
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
