using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnFruits : MonoBehaviour
{


    public List<GameObject> fruitPrefab = new List<GameObject>();
    public GameObject bomb;
    public float Z;
    public float start_y;
    public float lim_x_neg;
    public float lim_x_pos;
    public float timeBetweenSpawns;
    public GameObject finishLvl;

    private bool enable = true;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    void SpawnFruit()
    {

    if(Random.Range(0.0f, 100.0f) > DataContainerBetweenScenes.prob_bomb)
    {
        Vector3 pos = new Vector3(Random.Range(lim_x_neg, lim_x_pos), start_y + 10, Z);
        Instantiate(bomb, pos, bomb.transform.rotation);
    }
        

        int index_fruit = Random.Range(0, fruitPrefab.Count -1);
        Vector3 pos_fruit = new Vector3(Random.Range(lim_x_neg, lim_x_pos), start_y+10, Z);
        Instantiate(fruitPrefab[index_fruit], pos_fruit, fruitPrefab[index_fruit].transform.rotation); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > DataContainerBetweenScenes.timer)
        {
            enable = false;
            Invoke("Finish", 5.0f);
            
        }
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns && enable){
            timer = 0;
            SpawnFruit();
        }
    }

    public void Finish()
    {
        finishLvl.SetActive(true);
    }
}
