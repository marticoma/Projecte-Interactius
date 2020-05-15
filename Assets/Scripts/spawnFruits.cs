using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFruits : MonoBehaviour
{


    public List<GameObject> fruitPrefab = new List<GameObject>();
    public float Z;
    public float start_y;
    public float lim_x_neg;
    public float lim_x_pos;
    public float timeBetweenSpawns;
    private float mytime;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        mytime = Time.time;
    }

    void SpawnFruit()
    {
        int index_fruit = Random.Range(0, fruitPrefab.Count);
        Vector3 pos_fruit = new Vector3(Random.Range(lim_x_neg, lim_x_pos), start_y, Z);
        Instantiate(fruitPrefab[index_fruit], pos_fruit, fruitPrefab[index_fruit].transform.rotation); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mytime){
            mytime += timeBetweenSpawns;
            SpawnFruit();
        }
    }
}
