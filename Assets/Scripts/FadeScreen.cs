using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

    public Texture2D fadeTexture;

    [SerializeField] bool fadeOut = true;

    [Range(0.1f, 1f)]
    public float fadespeed = 0.2f;
    public int drawDepth = -1000;

    private float alpha;
    private float fadeDir = -1f;

    

    // Use this for initialization
    void Start()
    {
        alpha = fadeOut ? 0f : 1f;
    }

    void OnGUI()
    {

        if (fadeOut)
        {
            alpha -= fadeDir * fadespeed * Time.deltaTime;
        }
        else
        {
            alpha += fadeDir * fadespeed * Time.deltaTime;
        }

        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

    }

}