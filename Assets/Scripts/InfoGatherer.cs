using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(GameInstanceManager))]
public class InfoGatherer : MonoBehaviour
{
    [SerializeField]
    Transform  enemyContainer, enemyBulletContainer;

    [SerializeField] Transform player;
    float playerY;

    GameInstanceManager game;
    const float X_NORMA_FACTOR = 3.5f, Y_NORMA_FACTOR = 9f;

    private void Awake()
    {
        game = GetComponent<GameInstanceManager>();
        playerY = player.transform.position.y;
    }

    public bool GetPlayerAlive()
    {
        return player.GetComponent<AliveManager>().isPlayerAlive();
    }
    float GetPlayerX() 
    {
        return player.transform.localPosition.x/X_NORMA_FACTOR;
    }
    float[] GetEnemyInfo() 
    {
        float[] data = new float[9];
        List<Transform> enemies = new List<Transform>();
        foreach (Transform t in enemyContainer)
        {
            if (t.gameObject.activeSelf) { 
                if (t.position.y - playerY>-2)
                    enemies.Add(t); 
            }
        }
        enemies = enemies.OrderBy(obj => obj.position.y).ToList();

        for (int i = 0;i<3;i++)
        {
            if (i>=enemies.Count)
            {
                data[3 * i] = 0;
                data[3 * i+1] = 1;
                data[3 * i +2] = -1;
            }
            else
            {
                Transform en = enemies[i];
                data[3 * i] = en.localPosition.x/X_NORMA_FACTOR;
                data[3 * i + 1] = (en.position.y - playerY)/Y_NORMA_FACTOR;
                bool isKillable = en.GetComponent<DieToPlayerBullets>() != null;
                data[3 * i + 2] = isKillable ? 1 : -1;
            }
        }
        return data;
    }
    float [] GetBulletPositions() 
    {
        float[] data = new float[4];
        List<Transform> bullets = new List<Transform>();
        foreach (Transform t in enemyBulletContainer)
        {
            if (t.gameObject.activeSelf)
            {
                if (t.position.y - playerY > -2)
                    bullets.Add(t);
            }
        }
        bullets = bullets.OrderBy(obj => obj.position.y).ToList();

        for (int i = 0; i < 2; i++)
        {
            if (i >= bullets.Count)
            {
                data[2 * i] = 2;
                data[2 * i + 1] = 2;
            }
            else
            {
                Transform en = bullets[i];
                data[2 * i] = en.localPosition.x/X_NORMA_FACTOR;
                data[2 * i + 1] = (en.position.y - playerY)/Y_NORMA_FACTOR;
            }
        }
        return data;
    }

    public float [] GetInstanceInfo() 
    {
        float[] data = new float[14];
        float[] enemyData = GetEnemyInfo();
        float[] bulletData = GetBulletPositions();
        data[0] = GetPlayerX();
        for (int  i = 0;i<9;i++)
        {
            data[1 + i] = enemyData[i];
        }
        for (int i = 0; i<4;i++)
        {
            data[i + 10] = bulletData[i];
        }
        return data;
    }

    public int GetScore()
    {
        return game.GetCurrScore();
    }    
}
