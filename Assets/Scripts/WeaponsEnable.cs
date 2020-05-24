using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnable : MonoBehaviour
{
    public List<GameObject> Weapons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        bool[] enable = new bool[Weapons.Count];
        for(int i = 0; i < enable.Length; i++)
        {
            enable[i] = false;
        }

        switch (DataContainerBetweenScenes.level)
        {
            case 1:
                {
                    enable[0] = true;
                    break;
                }
            case 2:
                {
                    enable[1] = true;
                    enable[2] = true;
                    break;
                }
            case 3:
                {
                    enable[3] = true;
                    enable[4] = true;
                    break;
                }
            default:
                enable[0] = true;
                enable[1] = true;
                enable[2] = true;
                enable[3] = true;
                enable[4] = true;
                break;
        }

        for(int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].SetActive(enable[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
