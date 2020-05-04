using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class changeColor : MonoBehaviour
{

    public Material sphereMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.magnitude > 100 && pos.magnitude <150) sphereMaterial.SetColor("_Color", Color.white);
        else if(pos.magnitude > 150 && pos.magnitude < 200) sphereMaterial.SetColor("_Color", Color.red);
        else if (pos.magnitude > 200 && pos.magnitude < 250) sphereMaterial.SetColor("_Color", Color.blue);
        else if (pos.magnitude > 250 && pos.magnitude < 300) sphereMaterial.SetColor("_Color", Color.green);
        else if (pos.magnitude > 300) sphereMaterial.SetColor("_Color", Color.yellow);
    }
}
