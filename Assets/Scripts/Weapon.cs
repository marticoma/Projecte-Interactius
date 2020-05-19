using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private MainScript mainScript;
    public List<Fruit.eFruitType> fruitTypesList = new List < Fruit.eFruitType>(); // fruit types that this weapon can destroy
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


    void OnTriggerStay(Collider other){
        if (! didSlash) return; // if did not slash, weapon cannot do anything
        
        // cut fruit
        if (other.CompareTag("FruitTag")){
            Fruit.eFruitType fruitType = other.gameObject.GetComponent<Fruit>().type; // get type of fruit
            // check all types this weapon can cut
            for (int i = 0; i < fruitTypesList.Count; i++){
                if (fruitTypesList[i] == fruitType){ // type found -> cut fruit
                    other.gameObject.GetComponent<Fruit>().destroyFruit( transform.position - prev_pos);
                    mainScript.count++;

                }
            }
        }
        if (other.CompareTag("Bomb")){
            other.gameObject.GetComponent<Fruit>().destroyFruit( new Vector3(0,0,1));
            mainScript.lives--;
        }
    }

    void checkSlash(){
        didSlash = false; // reset
        Vector3 movement = transform.position - prev_pos;
        float movementSpeed = movement.magnitude / (Time.deltaTime * 1000); // in meter/milisec
        if (movementSpeed >= slashSpeedTolerance){ didSlash = true;}
    }
    // Update is called once per frame
    void Update()
    {
        checkSlash(); // did weapon slash?
        prev_pos = transform.position; // update previous position
    }
}
