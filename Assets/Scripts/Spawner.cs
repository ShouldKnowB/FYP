using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnSpeed;
    [SerializeField] Vector2 spawnDirection;
    [SerializeField] Transform objectPool;

    Vector2 velocityToGive;

    private void Start()
    {
        velocityToGive = spawnDirection.normalized * spawnSpeed;
    }

    public void Spawn()
    {
        List<GameObject> inactives = new List<GameObject>();
        foreach (Transform child in objectPool)
        {
            if (!child.gameObject.activeSelf)
            {
                inactives.Add(child.gameObject);
            }
        }
        if (inactives.Count == 0)
        {
            return;
        }
        GameObject target = inactives[Random.Range(0, inactives.Count - 1)];
        target.SetActive(true);
        target.transform.position = transform.position;
        Rigidbody2D rigid = target.GetComponent<Rigidbody2D>();
        rigid.velocity = velocityToGive;
    }
}
