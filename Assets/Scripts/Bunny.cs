using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rock>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (collision.gameObject.GetComponent<Defender>())
        {

            GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }
}
