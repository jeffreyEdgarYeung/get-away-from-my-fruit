﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(projectileSpeed, 0, 0) * Time.deltaTime);
    }
}
