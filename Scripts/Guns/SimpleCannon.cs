using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCannon : Cannon, IInterfaceCannon
{
    [SerializeField] protected Transform shootPos;
    [SerializeField] protected int damage;
    [SerializeField] protected int speed;
    public override void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = shootPos.transform.position;
        bullet.GetComponent<Bullet>().Init(speed, damage, shootPos.transform.forward);
    }
}