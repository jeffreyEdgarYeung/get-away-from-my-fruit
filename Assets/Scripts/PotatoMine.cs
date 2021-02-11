using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : MonoBehaviour
{
    [SerializeField] float armTime = 15f;

    [SerializeField] GameObject explosionPrefab;

    [Header("SFX")]
    [SerializeField] AudioClip armingSFX;
    [SerializeField] [Range(0f, 1f)] float armingVolume = 1f;
    [SerializeField] AudioClip beepSFX;
    [SerializeField] [Range(0f, 1f)] float beepVolume = 1f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(armTime);
        GetComponent<Animator>().SetBool("IsArmed", true);
        AudioSource.PlayClipAtPoint(armingSFX, Camera.main.transform.position, armingVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Animator>().GetBool("IsArmed") && collision.GetComponent<Attacker>())
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Beep()
    {
        AudioSource.PlayClipAtPoint(beepSFX, Camera.main.transform.position, beepVolume);
    }
}
