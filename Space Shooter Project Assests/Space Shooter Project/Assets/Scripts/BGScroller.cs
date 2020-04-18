﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public GameController gameController;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {

        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.score >= 40)
        {
            scrollSpeed = - 50;
        }
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }


}
