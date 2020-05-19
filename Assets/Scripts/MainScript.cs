using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    static public MainScript instance;
    public int count;
    public int lives;
    public Text textCount;
    public Text textLives;


    // on awake -> just one copy
    void Awake(){
        if (instance == null){
            instance = this;
        }else{Destroy(this);}
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        textCount.text = "Score: " + count.ToString();
        textLives.text = "Lives: " + lives.ToString();
        
    
    }
}
