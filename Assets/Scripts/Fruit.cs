using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject barrier;

    [Header("SFX")]
    [SerializeField] AudioClip loseSFX;
    [SerializeField] [Range(0f, 1f)] float loseVolume = 1f;
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            FindObjectOfType<MusicPlayer>().StopMusic();
            Time.timeScale = 0f;
            barrier.SetActive(true);
            AudioSource.PlayClipAtPoint(loseSFX, Camera.main.transform.position, loseVolume);
            StartCoroutine(FindObjectOfType<LevelController>().LoadGameOver(loseSFX.length));
        }
       
    }
}