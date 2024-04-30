using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillplayerOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<AliveManager>().Die();
        }
    }
}
