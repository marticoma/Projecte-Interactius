using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    static public MainScript instance;
    public int score;
    public int lives;
    public float timer; // in seconds
    public Text textCount;
    public Text textTimer;


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
        lives = 3;
        timer = 120;
    }

    // Update is called once per frame
    void Update()
    {
        textCount.text = score.ToString();
        timer -= Time.deltaTime;

        if (timer < 0.0f){ timer = 0.0f;}
        int minutes = (int)(timer /60);
        float seconds = timer - ( minutes * 60 );
        textTimer.text = minutes.ToString() + " : " + seconds.ToString("F3"); 
    
    }
}
