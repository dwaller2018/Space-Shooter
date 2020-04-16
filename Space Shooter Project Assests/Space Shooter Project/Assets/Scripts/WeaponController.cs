﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    public AudioSource musicSource;
    public AudioClip musicClipFive;

    void Start()
    {
        
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        musicSource.clip = musicClipFive;
        musicSource.Play();
    }
   
}
