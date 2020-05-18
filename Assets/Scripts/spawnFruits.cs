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
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    void SpawnFruit()
    {
        int index_fruit = Random.Range(0, fruitPrefab.Count);
        Vector3 pos_fruit = new Vector3(Random.Range(lim_x_neg, lim_x_pos), start_y+10, Z);
        Instantiate(fruitPrefab[index_fruit], pos_fruit, fruitPrefab[index_fruit].transform.rotation); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns){
            timer = 0;
            SpawnFruit();
        }
    }
}
