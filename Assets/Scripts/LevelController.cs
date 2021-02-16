using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [Header("SFX")]
    [SerializeField] AudioClip pauseSFX;
    [SerializeField] [Range(0f, 1f)] float pauseVolume = 1f;

    // State
    int numAttackers = 0;
    bool timerFinished = false;

    public void AttackerSpawned()
    {
        numAttackers++;
    }

    public void AttackerKilled( Vector3 attackerPos )
    {
        numAttackers--;
        if(numAttackers == 0 && timerFinished)
        {
            Debug.Log("End Level");
            Debug.Log("Death At:" + attackerPos);
        }
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

    public void SetTimerFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.SetSpawn(false);
        }
    }
}
