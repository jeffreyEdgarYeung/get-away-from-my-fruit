using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMusic : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<MusicPlayer>()) { Destroy(FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>()); }
    }
}
