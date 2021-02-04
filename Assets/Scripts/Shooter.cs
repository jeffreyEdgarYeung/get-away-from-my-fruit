using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun, projectile;
    //[SerializeField] float projectileSpeed = 1f;

    public void Fire()
    {
        GameObject bullet = Instantiate
        (
            projectile, 
            gun.transform.position, 
            Quaternion.identity
        );

        //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
    }
}
