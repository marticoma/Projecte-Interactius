using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnable : MonoBehaviour
{
    public List<GameObject> Weapons = new List<GameObject>();
    private int change = 1;

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
            case 4:
                {
                    enable[0] = true;
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

    void DisableAll()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DataContainerBetweenScenes.change_weapon_ingame)
        {
            if(Time.timeSinceLevelLoad > DataContainerBetweenScenes.time_to_change * change)
            {
                DisableAll();
                Weapons[Random.Range(0, Weapons.Count -1)].SetActive(true);
                change++;
            }

            else if (Time.timeSinceLevelLoad > DataContainerBetweenScenes.timer + 5)
            {
                DisableAll();
                Weapons[0].SetActive(true);
                DataContainerBetweenScenes.change_weapon_ingame = false;
            }
        }
    }
}
