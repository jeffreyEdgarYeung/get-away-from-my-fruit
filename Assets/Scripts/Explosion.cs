using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage = 125;

    [Header("SFX")]
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            collision.GetComponent<Health>().HandleHit(damage);
        }
    }
}
