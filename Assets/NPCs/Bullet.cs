using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        //if (col.gameObject.Equals(Level.Player))
        //{
        //    Debug.Log("HIT HIM");
        //    //send him back
        //    Level.Player.transform.Translate(new Vector3(Level.checkpoint.x, Level.checkpoint.y, 0) - Level.Player.transform.position);
        //}
        Destroy(gameObject, 4);
    }

}
