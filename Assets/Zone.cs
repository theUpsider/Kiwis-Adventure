using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public bool isWater;
    public bool isLava;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(player))
        {
            if (isWater)
            {
                player.transform.Translate(Level.checkpoints.Peek().position - player.transform.position);
                Debug.Log("teleported");
            }
            else if (isLava)
            {
                player.transform.Translate(GameObject.FindWithTag("Respawn").transform.position - player.transform.position);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
