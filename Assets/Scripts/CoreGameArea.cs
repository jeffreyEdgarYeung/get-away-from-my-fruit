using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        Debug.Log("Hello");
        SpawnDefender();
    }

    private void SpawnDefender()
    {
        GameObject newDefender = Instantiate(defender, GetSquareClicked(), Quaternion.identity);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.x = Mathf.Round(worldPosition.x);
        worldPosition.y = Mathf.Round(worldPosition.y);
        return worldPosition;
    }
}