using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float initSpawnDelay = 0f;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker[] enemyPrefabs;

    [Header("Final Wave")]
    [SerializeField] Attacker[] finalWaveAttackers;
    [SerializeField] float timeBetweenSpawns = 1f;

    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());

        /*
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnRandomAttacker();
        }
        */
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(initSpawnDelay);
        StartCoroutine(AttemptSpawn()); ;
    }

    private IEnumerator AttemptSpawn()
    {
        while (spawn)
        {
            SpawnRandomAttacker();
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
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

    public IEnumerator SpawnFinalWave()
    {
        foreach(Attacker attacker in finalWaveAttackers)
        {
            Attacker newEnemy = Instantiate
            (
                attacker,
                transform.position,
                Quaternion.identity
            ) as Attacker;
            newEnemy.transform.parent = transform;

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
