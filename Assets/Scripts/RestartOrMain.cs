using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrMain : MonoBehaviour
{

    private MainScript mainScript;
    public float slashSpeedTolerance;  // meter/milisec    tolerance to consider moving a Slash. 
    private Vector3 prev_pos;
    private bool didSlash; // if weapon attacked this is set to true 

    // Start is called before the first frame update
    void Start()
    {
        didSlash = false;
        prev_pos = transform.position;
        mainScript = MainScript.instance;
    }


    void OnTriggerEnter(Collider other)
    {
        if (!didSlash) return; // if did not slash, weapon cannot do anything

        // cut fruit
        if (other.CompareTag("Restart"))
        {
            SceneManager.LoadScene("Game");
        }
        if (other.CompareTag("GoToMain"))
        {
            DataContainerBetweenScenes.level = -1;
            SceneManager.LoadScene("Menu");
        }
    }

    void checkSlash()
    {
        didSlash = false; // reset
        Vector3 movement = transform.position - prev_pos;
        float movementSpeed = movement.magnitude / (Time.deltaTime * 1000); // in meter/milisec
        if (movementSpeed >= slashSpeedTolerance) { didSlash = true; }
    }

    // Update is called once per frame
    void Update()
    {
        checkSlash(); // did weapon slash?
        prev_pos = transform.position; // update previous position
    }
}
