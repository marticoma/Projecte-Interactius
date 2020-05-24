using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<AudioClip> bombList = new List<AudioClip>();
    public List<AudioClip> fruitCutList = new List<AudioClip>();
    public List<AudioClip> knifeMoveList = new List<AudioClip>();

    private Vector3 cameraPosition;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        cameraPosition = Camera.main.transform.position;
    }

    private void PlaySound(AudioClip clip) // 1
    {
         AudioSource.PlayClipAtPoint(clip, cameraPosition); // 2
    }
    public void PlayKnifeMoveClip()
    {
        int index = Random.Range(0, knifeMoveList.Count);
        PlaySound(knifeMoveList[index]);
    }

    public void PlayFruitCutClip()
    {
        int index = Random.Range(0, fruitCutList.Count);
        PlaySound(fruitCutList[index]);
    }

    public void PlayBombClip()
    {
        int index = Random.Range(0, bombList.Count);
        PlaySound(bombList[index]);
    }
    

}
