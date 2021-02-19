using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float appearDuration = .5f;

    [Header("SFX")]
    [SerializeField] AudioClip sfx;
    [SerializeField] [Range(0f, 1f)] float sfxVolume = 1f;

    IEnumerator Start()
    {
        AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position, sfxVolume);
        yield return new WaitForSeconds(appearDuration);
        Destroy(gameObject);
    }
}
