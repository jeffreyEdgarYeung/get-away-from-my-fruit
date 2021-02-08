using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    SunDisplay sunDisplay;

    void Start()
    {
        sunDisplay = FindObjectOfType<SunDisplay>();
    }

    private void OnMouseDown()
    {
        AttemptSpawnAt(GetSquareClicked());
    }

    private void SpawnDefender(Vector2 gridPosition)
    {
        if(defender == null) { return; }
        Defender newDefender = Instantiate(defender, gridPosition, Quaternion.identity) as Defender;
    }

    private void AttemptSpawnAt( Vector2 gridPosition )
    {
        if(defender.GetCost() <= sunDisplay.GetSun())
        {
            SpawnDefender(gridPosition);
            sunDisplay.SpendSun(defender.GetCost());
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.x = Mathf.Round(worldPosition.x);
        worldPosition.y = Mathf.Round(worldPosition.y);
        return worldPosition;
    }

    public void SetDefender( Defender defender )
    {
        this.defender = defender;
    }
}