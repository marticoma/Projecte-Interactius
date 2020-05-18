using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class adjusts z of this gameobject using the vector defined by (x,y) of origin and (x,y) of ending 
    
*/
public class ZRotateAdjust : MonoBehaviour
{

    public GameObject origin;
    public GameObject ending; 
    // Start is called before the first frame update
    private Vector3 standingStillDirection = new Vector3(0.0f,1.0f,0.0f); // if no rotation object should be facind this direction
    private Vector3 rotationAxis = new Vector3(0.0f,0.0f,1.0f); 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction =  ending.transform.position - origin.transform.position;
        direction.z = 0.0f;

        float angle = Vector3.SignedAngle(standingStillDirection, direction, rotationAxis );     

        transform.rotation = Quaternion.Euler(rotationAxis * angle);    
    }
}
