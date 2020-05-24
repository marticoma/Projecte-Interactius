using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CONTAINER OF DATA (AND UPDATE OF TIME) - NO OBJECT BEHAVIOURS HERE */
public class MainScript : MonoBehaviour
{
    static public MainScript instance;
    public int score;
    public int lives;
    public float timer; // in seconds


    // on awake -> just one copy
    void Awake(){
        if (instance == null){
            instance = this;
        }else{Destroy(this);}
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = DataContainerBetweenScenes.lives;
        timer = DataContainerBetweenScenes.timer;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }
}
