using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    int sunValue = 25;

    [Header("VFX")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 sunBankPosition;

    [Header("SFX")]
    [SerializeField] AudioClip sfx;
    [SerializeField] [Range(0f,1f)] float sfxVolume;


    // Cached refs
    SunDisplay sunDisplay;

    // State
    bool moving;

    void Start()
    {
        sunDisplay = FindObjectOfType<SunDisplay>();
        moving = false;
    }

    void Update()
    {
        if (moving)
        {
            MoveToBank();
        }

        if(transform.position == sunBankPosition)
        {
            Destroy(gameObject);
            sunDisplay.AddSun(sunValue);
        }

    }

    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(
            sfx,
            Camera.main.transform.position,
            sfxVolume
        );

        gameObject.GetComponent<Animator>().enabled = false;
        moving = true;
        Debug.Log("click");
    }

    private void MoveToBank()
    {
        Debug.Log("In Loop");
        transform.position = Vector3.MoveTowards(
            transform.position,
            sunBankPosition,
            moveSpeed * Time.deltaTime
        );
    }
}
