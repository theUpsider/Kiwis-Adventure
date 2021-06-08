using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{

    public GameObject PlayerDeathParticleSystem;

    private ParticleSystem system;

    public bool isWater;
    public bool isLava;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (isWater)
            {
                SoundManager.PlaySound(Sounds.death);

                StartCoroutine(WaitCamera(1.2f));

                Invoke("TeleportPlayer", 0.01f);
                Debug.Log("teleported");
            }
            else if (isLava)
            {
                SoundManager.PlaySound(Sounds.death);
                Level.Player.transform.Translate(GameObject.FindWithTag("Respawn").transform.position - Level.Player.transform.position);
                Level.Player.Deaths =+ 1;
            }
        }
    }

    private void TeleportPlayer()
    {
        Level.Player.transform.Translate(new Vector3(Level.checkpoint.x, Level.checkpoint.y, 0) - Level.Player.transform.position);
    }

    // every 2 seconds perform the print()
    private IEnumerator WaitCamera(float waitTime)
    {
        // Spawn death particles
        Instantiate(PlayerDeathParticleSystem, Level.Player.gameObject.transform.position, Quaternion.identity);
        GameObject waitASec = new GameObject("Waiting");
        waitASec.transform.position = Level.Player.gameObject.transform.position;

        Level.Camera.GetComponent<CameraFollow>();
        Level.Camera.GetComponent<CameraFollow>().target = waitASec.transform;
        yield return new WaitForSeconds(waitTime);
        Level.Camera.GetComponent<CameraFollow>().target = Level.Player.transform;
    }


}
