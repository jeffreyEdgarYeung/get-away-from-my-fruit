using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
}
