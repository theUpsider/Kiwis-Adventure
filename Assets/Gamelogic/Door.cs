using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IManager
{
    public GameObject destination;

    public void handlePlayerInput(GameObject Player, string message)
    {
        if (message == "Enter")
        {
            Debug.Log(this + " handle p input to: " + destination.transform.position);
            //Teleport player to destination
            if (destination != null)
                Player.transform.position = destination.transform.position;
        }
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            Level.subsribe(this);
        Debug.Log(this + " subsribed.");
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            Level.unsubscribe(this);
        Debug.Log(this + " unsubsribed.");
    }
}
