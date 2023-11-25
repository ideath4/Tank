using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : SimpleCannon
{

    public override void Shoot()
    {
        for (int i = 0; i < 7; i++)
        {
            Debug.Log(shootPos.transform.forward);
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shootPos.transform.position;
            bullet.GetComponent<Bullet>().Init(speed, damage,  new Vector3(shootPos.transform.forward.x + Random.Range(-.08f, .08f), 0, shootPos.transform.forward.z + Random.Range(-.08f,.08f)) );
        }
    }
}
