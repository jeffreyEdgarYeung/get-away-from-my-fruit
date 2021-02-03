using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    [SerializeField] float floatStrength;
    [SerializeField] float bobDelay = 0;
    Vector2 bobPosition;
    float originalY;

    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
    }

   
    // Update is called once per frame
    void Update()
    {
        bobPosition = transform.position;
        bobPosition.y = originalY + (Mathf.Sin(Time.time) * floatStrength);
        transform.position = bobPosition;
    }
  

    IEnumerator Bob()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            bobPosition = transform.position;
            bobPosition.y = originalY + (Mathf.Sin(Time.time) * floatStrength);
            transform.position = bobPosition;
        }

    }
}
