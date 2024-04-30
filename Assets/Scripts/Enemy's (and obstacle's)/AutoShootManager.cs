using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootManager : MonoBehaviour
{
    [SerializeField] Spawner bulletSpawner;
    [SerializeField] float shootCooldown;
    [SerializeField] int oddsToShoot;

    bool canShoot = true;

    private void Update()
    {
        if (!canShoot)
        {
            return;
        }
        if (Random.Range(1, oddsToShoot) == 1)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        bulletSpawner.Spawn();
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
