using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBomb : MonoBehaviour
{
    [SerializeField] float fuseTime = 1f;
    [SerializeField] GameObject explosionPrefab;

    [Header("VFX")]
    [SerializeField] [Range(0f, 1f)] float minShake;
    [SerializeField] [Range(0f, 1f)] float maxShake;
    [SerializeField] float growScale = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip sizzleSFX;
    [SerializeField] [Range(0f, 1f)] float sizzleVolume = 1f;

    float originalXPos, originalYPos;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        originalXPos = transform.position.x;
        originalYPos = transform.position.y;
        GetComponent<AudioSource>().PlayOneShot(sizzleSFX, sizzleVolume);
        yield return new WaitForSeconds(fuseTime);
        Explode();
    }

    void Update()
    {
        Shake();
        Grow();
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Shake()
    {
        Vector3 shakePos = new Vector3
        (
            Random.Range(minShake, maxShake) + originalXPos,
            Random.Range(minShake, maxShake) + originalYPos,
            transform.position.z
        );

        transform.position = shakePos;
    }

    private void Grow()
    {
        gameObject.transform.localScale *= growScale;
    }

    
}
