using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySunSpawner : MonoBehaviour
{
    [SerializeField] float xMin, xMax, yMin, yMax, coolDownMin, coolDownMax;
    [SerializeField] Sun sunPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSuns());
    }

    IEnumerator SpawnSuns()
    {
        while (true)
        {
            Vector3 spawnSpot = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0); 
            yield return new WaitForSeconds(Random.Range(coolDownMin, coolDownMax));
            Sun newSun = Instantiate(sunPrefab, spawnSpot, Quaternion.identity) as Sun;
            newSun.transform.parent = transform;
        }
        
    }
}
