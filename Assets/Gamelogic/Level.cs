using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public static Vector2 checkpoint;
    public static Player Player;
    public static List<IManager> playerInteractionSubscriber = new List<IManager>();
    public static GameObject Camera;

    public static void Notify(string message)
    {
        foreach (var sub in playerInteractionSubscriber)
            sub.HandlePlayerInput(Player, message);
    }

    public static void subsribe(IManager sub)
    {
        if (!playerInteractionSubscriber.Contains(sub))
            playerInteractionSubscriber.Add(sub);
    }
    public static void unsubscribe(IManager sub)
    {
        if (playerInteractionSubscriber.Contains(sub))
            playerInteractionSubscriber.Remove(sub);
    }
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       Camera = GameObject.FindGameObjectWithTag("MainCamera");
       //Set Cursor to not be visible
       Cursor.visible = false;
    }
}
