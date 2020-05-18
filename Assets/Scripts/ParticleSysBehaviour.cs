using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysBehaviour: MonoBehaviour
{
    private Vector3 standingStillDirection = new Vector3( 0,1,0);
    private Vector3 rotationAxis = new Vector3( 0,0,1);
    private ParticleSystem ps;

    // Start is called before the first frame update
       void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();

    //    ps.Pause(true);
  //      ps.Stop(true);
 //       ps.Clear();
    }

    public void PlayParticles(Vector3 direction, Vector3 color){
        float angle = Vector3.SignedAngle(standingStillDirection, direction, rotationAxis );   
        transform.Rotate (0.0f,0.0f, angle, Space.World);

        ps = GetComponent<ParticleSystem>();
        ps.Pause(false);
        ps.Play(true);
        Color realColor = new Color(color.x,color.y,color.z, ps.GetComponent<ParticleSystem>().startColor.a); // color of particles
        ps.GetComponent<ParticleSystem>().startColor = realColor;

    }

    // Update is called once per frame
    void Update () {
        // destroy after emitting everything
        if(!ps.IsAlive())
        {
            Destroy(gameObject);
        }
        
    }
}
