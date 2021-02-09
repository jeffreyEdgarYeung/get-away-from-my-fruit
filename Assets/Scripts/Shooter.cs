using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun, projectile;
    [SerializeField] float sfxVolume = 1f;
    [SerializeField] AudioClip fireSFX;

    public void Fire()
    {
        AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, sfxVolume);
        GameObject bullet = Instantiate
        (
            projectile, 
            gun.transform.position, 
            Quaternion.identity
        );

        bullet.transform.parent = transform;
    }
}
