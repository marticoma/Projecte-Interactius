using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class sphereControll : MonoBehaviour
{
    public GameObject sphere;
    public int initX;
    public int initY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        sphere.transform.position = transform.position + new Vector3(initX, initY, 0);
    }
}
