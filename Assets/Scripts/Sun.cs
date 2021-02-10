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
    GameObject body;

    void Start()
    {
        sunDisplay = FindObjectOfType<SunDisplay>();
        moving = false;
        body = transform.Find("Body").gameObject;
    }

    void Update()
    {
        if (moving)
        {
            MoveToBank();
        }

        if(body.transform.position == sunBankPosition)
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
    }

    private void MoveToBank()
    {
        body.transform.position = Vector3.MoveTowards(
            body.transform.position,
            sunBankPosition,
            moveSpeed * Time.deltaTime
        );
    }
}
