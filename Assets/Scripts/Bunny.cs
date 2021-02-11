using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] [Range(0f, 1f)] float jumpVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rock>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (collision.gameObject.GetComponent<Defender>())
        {

            GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }

    public void PlayJumpSFX()
    {
        AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position, jumpVolume);
    }
}
