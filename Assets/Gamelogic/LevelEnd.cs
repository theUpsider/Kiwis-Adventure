using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public GameObject toFade;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //disable camera follow
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

            //disable player input on character
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().runSpeed = 0;

            //move close to player
            StartCoroutine(Zoom());

        }
        Debug.Log(this + " subsribed.");
    }
    IEnumerator Zoom()
    {
        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 desiredScale = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 desiredPos = Level.Player.transform.position + new Vector3(0, 0, -1f);

        while (desiredScale.x + 0.1 <= Camera.transform.localScale.x
            || desiredScale.y + 0.1 <= Camera.transform.localScale.y || toFade.GetComponent<Image>().color.a <= 1)
        {
            Vector3 smoothedScale = Vector3.Lerp(Camera.transform.localScale, desiredScale, .2f);
            Vector3 smoothedPos = Vector3.Lerp(Camera.transform.position, Level.Player.transform.position + new Vector3(0, 0, -1f), 0.2f);

            Camera.transform.localScale = smoothedScale;//-= new Vector3(0.01f,0.01f,0.01f);
            Camera.transform.position = smoothedPos;

            toFade.GetComponent<Image>().color = toFade.GetComponent<Image>().color + new Color(0, 0, 0, 0.02f);



            yield return new WaitForSeconds(.1f);
        }

        Debug.Log("Camera eached end target");
        SceneManager.LoadScene(2);
        yield break;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
