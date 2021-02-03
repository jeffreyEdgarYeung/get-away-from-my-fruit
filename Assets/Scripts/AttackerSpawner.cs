using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker enemyPrefab;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnAttacker();
        }
        
    }

    private void SpawnAttacker()
    {
        var newEnemy = Instantiate
        (
            enemyPrefab,
            transform.position,
            Quaternion.identity
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
