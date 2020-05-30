using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour, IManager
{
    [SerializeField]   public bool hasKiwiThrow = false;

    public void handlePlayerInput(GameObject player, string message)
    {
        if (message == "Fire1")
        {
            if (hasKiwiThrow)
            {
                //TODO kiwi on inventory --
                // launch new kiwi flying
                Debug.Log("LOL");

            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Level.subsribe(this);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
