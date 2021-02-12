using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioClip hitSFX;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 1f;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (collision.gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }

    public void PlayHitSFX()
    {
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, hitVolume);
    }

}
