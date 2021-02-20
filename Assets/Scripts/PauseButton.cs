using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<LevelController>().TogglePause();
    }
}
