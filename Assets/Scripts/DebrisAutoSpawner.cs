using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class DebrisAutoSpawner : MonoBehaviour
{
    [SerializeField] float cycletime, startOffset;
    [SerializeField] int oddsToSpawn;

    Spawner m_spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        m_spawner = GetComponent<Spawner>();
        StartCoroutine(Loop());

    }

    // Update is called once per frame
    IEnumerator Loop()
    {
        yield return new WaitForSeconds(startOffset);
        for(; ; )
        {
            yield return new WaitForSeconds(cycletime);
            if (Random.Range(1, oddsToSpawn) == 1)
            {
                m_spawner.Spawn();
            }
        }
    }
}
