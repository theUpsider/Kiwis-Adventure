using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform BulletStartPos;

    private float nextActionTime = 0.0f;
    public float period = 1f;

    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            Instantiate(BulletPrefab, BulletStartPos.position,BulletStartPos.rotation);
        }
    }
}
