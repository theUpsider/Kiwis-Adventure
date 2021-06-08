﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public new BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(Level.Player.gameObject))
        {
            Debug.Log("worked checkpoint");
            if (!Level.checkpoint.Equals(this.transform.position))
                Level.checkpoint =this.transform.position;
            collider.enabled = false;
            SoundManager.PlaySound(Sounds.checkpoint);
        }
    }
}
