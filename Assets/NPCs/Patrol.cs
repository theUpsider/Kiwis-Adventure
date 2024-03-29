﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    [FormerlySerializedAs("Own Collider (optional)")]
    public Collider2D ownCollider;
    public bool movingRight = true;
    public Transform envDetection;
    [FormerlySerializedAs("Layer Mask")]
    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(envDetection.position, Vector2.down, distance, layerMask);
        RaycastHit2D wallInfo = Physics2D.Raycast(envDetection.position, (this.transform.position - envDetection.position).normalized, distance,layerMask);
        if ((groundInfo.collider == ownCollider) || (wallInfo.collider == ownCollider))
            return; //ignore self
        if (!groundInfo.collider || wallInfo.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
