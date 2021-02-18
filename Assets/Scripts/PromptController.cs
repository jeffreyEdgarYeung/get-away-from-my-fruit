using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour
{
    [SerializeField] string[] prompts;
    [SerializeField] float initPromptDelay = 0f;
    [SerializeField] float promptDuration = 5f;

    [SerializeField] GameObject promptPrefab;
    [SerializeField] GameObject finalWavePrompt;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(initPromptDelay);
        StartCoroutine(ShowPrompts());
    }

    IEnumerator ShowPrompts()
    {
        foreach(string prompt in prompts)
        {
            GameObject newPrompt = Instantiate
            (
                promptPrefab,
                new Vector3(5f, 1.5f, 0),
                Quaternion.identity
            ) as GameObject;

            newPrompt.GetComponent<Transform>().GetComponentInChildren<Text>().text = prompt;
            newPrompt.GetComponent<Transform>().SetParent(transform);
            yield return new WaitForSeconds(promptDuration);
            Destroy(newPrompt);
        }
       
    }

    public IEnumerator ShowFinalWavePrompt()
    {
        GameObject finalPrompt = Instantiate
        (
            finalWavePrompt,
            new Vector3(5f, 3f, 0),
            Quaternion.identity
        ) as GameObject;
        finalPrompt.GetComponent<Transform>().SetParent(transform);
        yield return new WaitForSeconds(2f);

        Destroy(finalPrompt);
    }
}
