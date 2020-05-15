using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class sphereCollect : MonoBehaviour
{

    float CheckForce()
    {
        Vector3 pos = gameObject.transform.position;
        float x = Mathf.Abs(pos.x);
        if(pos.x > 0)
        {
            x *= -1;
        }

        return 15*x;
    }
    // Start is called before the first frame update
    void Start()
    {
        float x = CheckForce();
        float y = 25000 + Mathf.Abs(x);
        Vector3 force = new Vector3(x, y, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(force);
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, -50, 0);
        if (gameObject.transform.position.y < -700)
            Destroy(gameObject, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
            Destroy(gameObject, 0);
    }
}
