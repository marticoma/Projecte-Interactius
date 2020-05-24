using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public enum eFruitType { RED, YELLOW, GREEN, BOMB };

    public GameObject particlesSys; // particle system prefab
    public static float fruitSpeed = 500;
    private Vector3 rotation;

    public eFruitType type; // type of fruit
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
        float y = 22000 + Mathf.Abs(x/15*5);
        if (Mathf.Abs(x/15*5) < 2000)
        {
            y += 5000;
        }
        Vector3 force = new Vector3(x, y, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(force);
        gameObject.GetComponent<Rigidbody>().useGravity = false;

        rotation.Set(Random.Range(-45.0f, 45.0f), Random.Range(-45.0f, 45.0f),Random.Range(-45.0f, 45.0f));

// better if we use velocity instead of initial forces
//        float angle = Random.Range(-45.0f, 45.0f);
//       gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (Mathf.Sin(angle), Mathf.Cos(angle), 0) * fruitSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, -50, 0);
        transform.Rotate(rotation*Time.deltaTime*3);

        // if out of map -> destroy instance
        if (gameObject.transform.position.y < -600)
            Destroy(gameObject, 0);
    }

    // destroyFruit is called by a Weapon. Weapons decide which fruits can be cut
   public void destroyFruit(Vector3 effectDirection){
        
        // instantiate particle system with a certain color
        GameObject psobj = Instantiate(particlesSys, transform.position, transform.rotation);
        Vector3 rgb = new Vector3(0,0,0);
        switch(type){
            case eFruitType.RED:
                rgb = new Vector3 (1.0f,0.0f,0.0f);
                break;
            case eFruitType.GREEN:
                rgb = new Vector3 (0.0f,0.7f,0.2f);
                break;
            case eFruitType.YELLOW:
                rgb = new Vector3 (1.0f,1.0f,0.0f);
                break;
            default:
            {
                ParticleSystem ps = psobj.GetComponent<ParticleSystem>();
                var shape = ps.shape;
                shape.shapeType = ParticleSystemShapeType.Sphere; 
                //shape does not need to be put to psobj because unity does some magic

                rgb = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            }
        }

        psobj.GetComponent<ParticleSysBehaviour>().PlayParticles(effectDirection, rgb);
        Destroy (gameObject, 0);
    }

}
