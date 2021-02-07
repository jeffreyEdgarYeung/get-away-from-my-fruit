using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        SpawnDefender();
    }

    private void SpawnDefender()
    {
        Defender newDefender = Instantiate(defender, GetSquareClicked(), Quaternion.identity) as Defender;
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