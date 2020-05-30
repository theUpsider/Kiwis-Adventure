using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public static Vector2 checkpoint;
    public static GameObject Player;
    public static List<IManager> playerInteractionSubscriber = new List<IManager>();

    public static void Notify(string message)
    {
        foreach (var sub in playerInteractionSubscriber)
            sub.handlePlayerInput(Player, message);
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
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
