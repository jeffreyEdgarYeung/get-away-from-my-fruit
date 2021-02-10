using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    [SerializeField] Sun sunPrefab;
    [SerializeField] float initDropWait = 7.75f;
    [SerializeField] float coolDownMin = 0f;
    [SerializeField] float coolDownMax = 10f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(initDropWait);
        SpawnSun();
        StartCoroutine(SpawnSuns());
        
    }

    IEnumerator SpawnSuns()
    {
        while( true )
        {
            yield return new WaitForSeconds(Random.Range(coolDownMin, coolDownMax));
            SpawnSun();
        }
    }

    private void SpawnSun()
    {
        Vector3 sunSpot = new Vector3(transform.position.x, transform.position.y, -1);
        Sun newSun = Instantiate(sunPrefab, sunSpot, Quaternion.identity) as Sun;
        newSun.transform.parent = transform;
    }
}
