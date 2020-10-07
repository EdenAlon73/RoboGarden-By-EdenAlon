using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] Attacker[] attackerPrefabArray; 
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private float spawnTimeDelay = 2f;
    [SerializeField] private float timeIncrement = .25f;
    [SerializeField] private bool doISpawnOverTime;
    

    
    IEnumerator Start()
    {
        
            while (spawn && !doISpawnOverTime)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
                if (spawn)
                {
                    SpawnAttacker();
                }
            
            }
            
            while (spawn && doISpawnOverTime)
            {
                yield return new WaitForSeconds(spawnTimeDelay);
                spawnTimeDelay -= timeIncrement;
                if (spawn)
                {
                    SpawnAttacker();
                }
            
            }
            
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        SpawnEnemy(attackerPrefabArray[attackerIndex]);
    }

    private void SpawnEnemy(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
