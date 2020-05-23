﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position - offset;
    }


}
