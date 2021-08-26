// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] List<Attacker> attackerTypesPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnCoroutine()
    {

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay)); //It gives random delays to spawn.
            if (spawn)
            {
                spawnAttacker();
            }
            
        }
    }

    private void spawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerTypesPrefabs.Count);
        Attacker newAttacker = Instantiate(attackerTypesPrefabs[attackerIndex], transform.position, transform.rotation) as Attacker;//Spawn Lizard for now.
        newAttacker.transform.parent = transform;
        
    }
    public void stopSpawning()
    {
        spawn = false;
    }
}
