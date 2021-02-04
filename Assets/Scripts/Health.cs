using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;

    [Header("On Hit Effects")]
    [SerializeField] Color hitTint;
    [SerializeField] float hitFlashDuration = 0.1f;
    [SerializeField] AudioClip[] hitSounds;
    [SerializeField] float hitVolume = 1f;

    // Cached Refs
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    float health;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleHit(float damage)
    {
        PlayHitVFX();
        StartCoroutine(HitFlash());
        DealDamage(damage);        
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if ( health <= 0) { Destroy(gameObject); }
    }

    private IEnumerator HitFlash()
    {
        spriteRenderer.color = hitTint;
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.color = new Color(1,1,1,1);
    }

    private void PlayHitVFX()
    {
        AudioSource.PlayClipAtPoint(
            hitSounds[Random.Range(0, hitSounds.Length)],
            Camera.main.transform.position,
            hitVolume
        );
    }
}
