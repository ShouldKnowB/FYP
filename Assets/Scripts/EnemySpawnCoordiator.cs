using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCoordiator : MonoBehaviour
{
    [SerializeField] Transform containerOfSpawners;
    [SerializeField] float cycleTime;
    [SerializeField] int oddsToSpawn;
    Spawner[] spawners;

    private void Awake()
    {
        spawners = new Spawner[containerOfSpawners.childCount];
        int i = 0;
        foreach (Transform t in containerOfSpawners)
        {
            spawners[i] = t.GetComponent<Spawner>();
            i++;
        }
        StartSpawning();
    }

    IEnumerator SpawnLogicLoop()
    {
        while (true)
        {
            if (Random.Range(1, oddsToSpawn) == 1)
            {
                int rand = Random.Range(0, spawners.Length);
                spawners[rand].Spawn();
            }
            yield return new WaitForSeconds(cycleTime);
        }
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
        foreach (Spawner s in spawners) { s.DeleteAll(); }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnLogicLoop());
    }

}
