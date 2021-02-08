using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    int sunValue = 25;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 sunBankPosition;


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
        }
        
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        moving = true;
        sunDisplay.AddSun(sunValue);
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
