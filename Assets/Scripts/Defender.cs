using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int sunCost = 100;
    [SerializeField] Defender shovel;     // Used to recognize removal

    public int GetCost() { return sunCost; }

    private void OnMouseDown()
    {
        if(FindObjectOfType<DefenderSpawner>().GetDefender() == shovel)
        {
            Instantiate(shovel, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        GameObject.Find("/Defender Bar/Shovel Button").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 170);
        FindObjectOfType<DefenderSpawner>().SetDefender(null);
    }
}
