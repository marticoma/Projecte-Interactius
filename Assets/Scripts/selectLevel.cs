using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectLevel : MonoBehaviour
{
    private MainScript mainScript;
    public List<Fruit.eFruitType> fruitTypesList = new List<Fruit.eFruitType>(); // fruit types that this weapon can destroy
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


    void OnTriggerStay(Collider other)
    {
        if (!didSlash) return; // if did not slash, weapon cannot do anything

        // cut fruit
        if (other.CompareTag("Level1"))
        {
            SceneManager.LoadScene("Game1");
        }
        if (other.CompareTag("Level2"))
        {
            SceneManager.LoadScene("Game2");
        }
        if (other.CompareTag("Level3"))
        {
            SceneManager.LoadScene("Game3");
        }
        if (other.CompareTag("Level4"))
        {
            SceneManager.LoadScene("SampleScene");
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
