using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float projectileDamage = 30f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(projectileSpeed, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            collision.gameObject.GetComponent<Health>().HandleHit(projectileDamage);
            Destroy(gameObject);
        }
    }
}
