using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class sphereCollect : MonoBehaviour
{

    public float speed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        float xDirection = -transform.position.normalized.x + Random.Range(-0.7f, 0.7f);
        float yDirection = -transform.position.normalized.y + Random.Range(-0.7f, 0.7f); ;
        direction = new Vector3(xDirection, 0, yDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 0);
    }
}
