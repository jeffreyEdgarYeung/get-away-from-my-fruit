using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker[] enemyPrefabs;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnRandomAttacker();
        }
        
    }

    private void SpawnRandomAttacker()
    {
        Attacker newEnemy = Instantiate
        (
            enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
            transform.position,
            Quaternion.identity
        ) as Attacker;

        newEnemy.transform.parent = transform;
    }

    public void SetSpawn(bool spawn){ this.spawn = spawn; }
}
