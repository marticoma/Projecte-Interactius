﻿using System.Collections;
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


    void OnTriggerEnter(Collider other)
    {
        if (!didSlash) return; // if did not slash, weapon cannot do anything

        // cut fruit
        if (other.CompareTag("Level1"))
        {
            DataContainerBetweenScenes.level = 1;
            DataContainerBetweenScenes.lives = 10;
            DataContainerBetweenScenes.timer = 45.0f;

        }
        if (other.CompareTag("Level2"))
        {
            DataContainerBetweenScenes.level = 2;
            DataContainerBetweenScenes.lives = 7;
            DataContainerBetweenScenes.timer = 45.0f;
        }
        if (other.CompareTag("Level3"))
        {
            DataContainerBetweenScenes.level = 3;
            DataContainerBetweenScenes.lives = 5;
            DataContainerBetweenScenes.timer = 45.0f;

        }
        if (other.CompareTag("Level4"))
        {
            DataContainerBetweenScenes.change_weapon_ingame = true;
            DataContainerBetweenScenes.level = 4;
            DataContainerBetweenScenes.lives = 3;
            DataContainerBetweenScenes.timer = 90.0f;

        }

        if(DataContainerBetweenScenes.level != -1)
        {
            SceneManager.LoadScene("Game");
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
