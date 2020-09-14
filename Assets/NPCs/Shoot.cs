using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform BulletStartPos;

    private float nextActionTime = 0.0f;
    public float period = 1f;

    public GameObject BulletPrefab;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            Debug.Log(BulletStartPos.position);
            Instantiate(BulletPrefab, BulletStartPos.position + new Vector3((sr.flipX ? -1 : 1), 0, 0), Quaternion.AngleAxis(GetComponent<SpriteRenderer>().flipX ? 180 : 0,Vector3.down));
        }
    }
}
