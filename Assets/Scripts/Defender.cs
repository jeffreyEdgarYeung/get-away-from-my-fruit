using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int sunCost = 100;

    [Header("Shovel Removal")]
    [SerializeField] Defender shovel;        // Used to recognize removal
    [SerializeField] GameObject fieldCursor;

    GameObject thisFieldCursor;

    public int GetCost() { return sunCost; }

    /*
     * All following functions are for removal of defender through shovel
     */

    private void OnMouseDown()
    {
        if (GetComponent<Shovel>()) { return; }
        if(FindObjectOfType<DefenderSpawner>().GetDefender() == shovel)
        {
            Instantiate(shovel, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(thisFieldCursor);
            GameObject.Find("/Defender Bar/Shovel Button").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 170);
            FindObjectOfType<DefenderSpawner>().SetDefender(null);
        } 
    }

    private void OnMouseEnter()
    {
        if (GetComponent<Shovel>()) { return; }

        if (FindObjectOfType<DefenderSpawner>().GetDefender() != shovel) { return; }
        thisFieldCursor = Instantiate
        (
            fieldCursor, 
            transform.position, 
            Quaternion.identity
        ) as GameObject;
    }

    private void OnMouseExit() 
    {
        if (GetComponent<Shovel>()) { return; }

        if (thisFieldCursor)
        {
            Destroy(thisFieldCursor);
        }
    }
}
