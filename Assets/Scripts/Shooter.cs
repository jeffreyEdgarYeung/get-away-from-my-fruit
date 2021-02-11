using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun, projectile;
    [SerializeField] float sfxVolume = 1f;
    [SerializeField] AudioClip fireSFX;

    AttackerSpawner myLaneSpawner;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        SetLaneSpawner();
    }

    void Update()
    {
        if (AttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            if (InSameLane(spawner))
            {

                myLaneSpawner = spawner;
                break;
            }
        }
    }

    public void Fire()
    {
        if (fireSFX)
        {
            AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, sfxVolume);
        }
        GameObject bullet = Instantiate
        (
            projectile, 
            gun.transform.position, 
            Quaternion.identity
        );

        bullet.transform.parent = transform;
    }

    private bool InSameLane(AttackerSpawner x)
    {
        return (Mathf.Abs(x.transform.position.y - transform.position.y) <= Mathf.Epsilon);
    }

    private bool AttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }
}
