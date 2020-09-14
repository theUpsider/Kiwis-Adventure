using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour
{
    public GameObject toHide;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //make particle
            //if (Player.TryGetComponent<Inventory>(out playerinv))
                Level.Player.AddKiwis(1);
                Debug.Log("Player Kiwis: " + Level.Player.GetKiwis());
            SoundManager.PlaySound(Sounds.kiwi);

            toHide.SetActive(false);
        }

    }
}
