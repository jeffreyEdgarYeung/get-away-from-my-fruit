using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioClip loseSFX;
    [SerializeField] [Range(0f, 1f)] float loseVolume = 1f;
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        AudioSource.PlayClipAtPoint(loseSFX, Camera.main.transform.position, loseVolume);
        StartCoroutine(FindObjectOfType<LevelLoader>().LoadGameOver(loseSFX.length));
       
    }
}