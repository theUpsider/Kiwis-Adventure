using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public bool isWater;
    public bool isLava;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(Level.Player))
        {
            if (isWater)
            {
                Level.Player.transform.Translate(new Vector3(Level.checkpoint.x, Level.checkpoint.y, 0) - Level.Player.transform.position);
                Debug.Log("teleported");
            }
            else if (isLava)
            {
                Level.Player.transform.Translate(GameObject.FindWithTag("Respawn").transform.position - Level.Player.transform.position);

            }
        }
    }

}
