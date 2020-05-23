using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    private MainScript ms;
   
// LIVES
    // canvas position of first life and horizontal offset to put more lives
    public Vector3 livesStartingPoint;
    public float livesXOffset;
    public GameObject lifeParentObject;
    public GameObject lifePrefab;
    private Stack<GameObject> lifeStack = new Stack<GameObject>();
 
 
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
                // first life has no offset -->  life1 = startingPos
                Vector3 offset = new Vector3(livesXOffset * (float)(fakeLives), 0.0f, 0.0f);
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
        
        if (lifeStack.Count != ms.lives){ updateLives(); }
        
    }
}
