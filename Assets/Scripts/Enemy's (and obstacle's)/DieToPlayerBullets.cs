using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieToPlayerBullets : MonoBehaviour
{
    const int SCORE_VALUE = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            collision.gameObject.SetActive(false);
            GetKilled();
        }
    }

    void GetKilled()
    {
        GameInstanceManager instance = GameInstanceManager.
            GetObjectGameInstance(transform);

        instance.IncreaseScore(SCORE_VALUE);
        instance.PlayEnemyHitSystem(transform);
        instance.PlayKillEnemyClip();
        gameObject.SetActive(false);
    }
}
