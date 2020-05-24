using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    private MainScript ms;
   
// LIVES
    // canvas position of first life and horizontal offset to put more lives
    public Vector3 livesStartingPoint;
    public Vector2 livesOffset;
    public GameObject lifeParentObject;
    public GameObject lifePrefab;
    private Stack<GameObject> lifeStack = new Stack<GameObject>();
 
    public Text scoreText;
    public Text timeText;
 
    // Start is called before the first frame update
    void Start()
    {
        ms = MainScript.instance;
         // first update will execute updateLives. Ensure mainscript has initialized variables
    }

    public void updateLives(){
        // extract variable to ease coding
        int realLives = ms.lives;
        int fakeLives = lifeStack.Count;
        while(realLives != fakeLives){
            // mainscript has more lives
            if (realLives > fakeLives){
                // first life has no offset -->  life1 = startingPos, life5 = (startingpos.x, startingpos.y-offset)
                int posx = fakeLives % 5;
                int posy = fakeLives / 5;
                Vector3 offset = new Vector3(livesOffset.x * (float)posx, livesOffset.y * (float)(posy), 0.0f);
                GameObject obj = Instantiate(lifePrefab);
                obj.transform.SetParent(lifeParentObject.transform);
                obj.transform.localPosition = livesStartingPoint + offset;
                obj.transform.localRotation = Quaternion.identity;
                lifeStack.Push( obj );
            }
            
            // mainscript has less lives (and list has lives to pop)
            if (realLives < fakeLives){
                if (fakeLives == 0){ return; } // Cannot pop anything else
                GameObject obj = lifeStack.Pop();
                Destroy(obj);
            }

            fakeLives = lifeStack.Count;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // display score
        scoreText.text = ms.score.ToString();

        // display time
        float timer  =ms.timer;
        if (timer < 0.0f) { timer = 0.0f; }

        int minutes = (int)(timer /60);
        float seconds = timer - ( minutes * 60 );
        timeText.text = minutes.ToString() + " : " + seconds.ToString("F3"); 


        if (lifeStack.Count != ms.lives){ updateLives(); }
        
    }
}
