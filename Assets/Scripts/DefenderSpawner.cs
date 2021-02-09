using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    SunDisplay sunDisplay;
    [SerializeField] AudioClip[] spawnSFX;
    [SerializeField] [Range(0f, 1f)] float sfxVolume;

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
        Defender newDefender = Instantiate(defender, gridPosition, Quaternion.identity) as Defender;

        AudioSource.PlayClipAtPoint(
            spawnSFX[Random.Range(0, spawnSFX.Length)],
            Camera.main.transform.position, 
            sfxVolume
        );

        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(255, 214, 137, 85);
        }

        this.defender = null;
    }

    private void AttemptSpawnAt( Vector2 gridPosition )
    {
        if (defender == null) { return; }
        if (defender.GetCost() <= sunDisplay.GetSun())
        {
            sunDisplay.SpendSun(defender.GetCost());
            SpawnDefender(gridPosition);
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