using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBackGround : MonoBehaviour
{
    public List<Sprite> backs = new List<Sprite>();
    public SpriteRenderer background;

    // Start is called before the first frame update
    void Start()
    {
        background = gameObject.GetComponent<SpriteRenderer>();
        if (DataContainerBetweenScenes.level == -1)
        {
            background.sprite = backs[backs.Count - 1];
        }
        else
        {
            background.sprite = backs[DataContainerBetweenScenes.level -1];
        }
    }
}
