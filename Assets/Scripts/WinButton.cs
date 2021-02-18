using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButton : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 centerScreenPosition;
    [SerializeField] float growScale = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip sfx;
    [SerializeField] [Range(0f, 1f)] float sfxVolume;

    // State
    bool moving;
    GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        body = transform.Find("Body").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Grow();
            MoveToCenter();
        }
    }

    private void OnMouseDown()
    {
        FindObjectOfType<MusicPlayer>().StopMusic();
        AudioSource.PlayClipAtPoint(
            sfx,
            Camera.main.transform.position,
            sfxVolume
        );

        WinButton[] winButtons = FindObjectsOfType<WinButton>();

        foreach(WinButton button in winButtons)
        {
            button.GetComponent<Animator>().enabled = false;
            button.StartMoving();
        }

        StartCoroutine(Transition());
        
    }

    private void MoveToCenter()
    {
        body.transform.position = Vector3.MoveTowards(
            body.transform.position,
            centerScreenPosition,
            moveSpeed * Time.deltaTime
        );
    }

    private void Grow()
    {
        gameObject.transform.localScale *= growScale;
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(sfx.length - 2f);
        StartCoroutine(FindObjectOfType<LevelLoader>().LoadNextScene());
    }

    public void StartMoving()
    {
        moving = true;
    }

   
}
