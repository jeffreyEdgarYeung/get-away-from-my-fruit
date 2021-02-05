using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] float hoverRatio = 1.1f;

    // Cached refs
    SpriteRenderer spriteRenderer;

    // State
    Vector3 hoverSize;
    Vector3 normalSize;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        hoverSize = gameObject.transform.localScale * hoverRatio;
        normalSize = gameObject.transform.localScale;
    }

    private void OnMouseOver()
    {
        gameObject.transform.localScale = hoverSize;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = normalSize;
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(255, 214, 137, 85);
        }

        spriteRenderer.color = Color.white;
    }
}
