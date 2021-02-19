using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float appearDuration = .5f;

    [Header("SFX")]
    [SerializeField] AudioClip sfx;
    [SerializeField] [Range(0f, 1f)] float sfxVolume = 1f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position, sfxVolume);
        yield return new WaitForSeconds(appearDuration);
        Destroy(gameObject);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In there");
        if (collision.GetComponent<Defender>())
        {
            collision.GetComponent<Health>().DealDamage(1000);
        }
    }
    */
}
