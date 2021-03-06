﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { 
    [System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private Rigidbody rb;

    public AudioSource musicSource;
    public AudioClip musicClipOne;
    //public AudioClip musicClipTwo;
    //public AudioClip musicClipOne;
    //public AudioClip musicClipOne;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag ("PowerUp"))
        {
            Destroy(other.gameObject);
            fireRate = fireRate/2;
        }
       


    }

}
