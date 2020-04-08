using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour
{
    public GameObject Player;
    public GameObject toHide;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(Player))
        {
            //make particle
            Inventory playerinv;
            if (Player.TryGetComponent<Inventory>(out playerinv))
            {
                playerinv.AddKiwis(1);
                Debug.Log("Player Kiwis: " + playerinv.GetKiwis());
            }
            else
                Debug.Log("No inv found on player");
            toHide.SetActive(false);
        }

    }
}
