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

    [Header("Death Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float xAdjust = 0f;
    [SerializeField] float yAdjust = 0f;

    // Cached Refs
    SpriteRenderer spriteRenderer;

    float health;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleHit(float damage)
    {
        PlayHitSFX();
        StartCoroutine(HitFlash());
        DealDamage(damage);        
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if ( health <= 0) 
        { 
            Destroy(gameObject);
            PlayDeathVFX();
        }
    }

    private IEnumerator HitFlash()
    {
        spriteRenderer.color = hitTint;
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.color = new Color(1,1,1,1);
    }

    private void PlayHitSFX()
    {
        AudioSource.PlayClipAtPoint(
            hitSounds[Random.Range(0, hitSounds.Length)],
            Camera.main.transform.position,
            hitVolume
        );
    }

    private void PlayDeathVFX()
    {
        Vector3 dVFXPos = new Vector3(
            transform.position.x + xAdjust,
            transform.position.y + yAdjust,
            transform.position.z
        );

        GameObject ghost = Instantiate( deathVFX, dVFXPos, Quaternion.identity);
        Destroy(ghost, 3f);

    }
}
