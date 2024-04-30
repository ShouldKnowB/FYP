using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayerBullets : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("PlayerBullet"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
