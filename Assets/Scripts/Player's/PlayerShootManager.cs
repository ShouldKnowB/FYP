using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    [SerializeField] Spawner bulletSpawner;
    [SerializeField] float shootCooldown = 1f;
    GameInstanceManager gameInstance;

    bool canShoot = true;

    private void Start()
    {
        gameInstance = GameInstanceManager.GetObjectGameInstance(transform);
    }
    public void Shoot()
    {
        if (!canShoot) return;
        StartCoroutine(MakeCooldown());
        gameInstance.PlayPlayerShootSound();
        bulletSpawner.Spawn();
    }

   IEnumerator MakeCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
