using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<Fruit.eFruitType> fruitTypesList = new List < Fruit.eFruitType>(); // fruit types that this weapon can destroy
    public float slashTolerance;  // tolerance to consider moving a Slash
    private Vector3 prev_pos;
    private bool didSlash; // if weapon attacked this is set to true 
    // Start is called before the first frame update
    void Start()
    {
        didSlash = false;
        prev_pos = transform.position;        
    }


    void OnTriggerStay(Collider other){
        // cut fruit
        if (other.CompareTag("FruitTag") && didSlash){
            Fruit.eFruitType fruitType = other.gameObject.GetComponent<Fruit>().type; // get type of fruit
            // check all types this weapon can cut
            for (int i = 0; i < fruitTypesList.Count; i++){
                if (fruitTypesList[i] == fruitType){ // type found -> cut fruit
                    other.gameObject.GetComponent<Fruit>().destroyFruit( transform.position - prev_pos);
                }
            }
        }
    }

    void checkSlash(){
        didSlash = false; // reset
        Vector3 movement = transform.position - prev_pos;
        float distance = movement.x * movement.x + movement.y * movement.y; //avoid square root. Z is not used for weapons
        if ((slashTolerance*slashTolerance) < distance){ // slashTolerance ^2 < realDistance ^2
            didSlash = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkSlash(); // did weapon slash?
        prev_pos = transform.position; // update previous position
    }
}
