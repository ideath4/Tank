using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCannon : Cannon, IInterfaceCannon
{
    [SerializeField] List<Transform> ShootPositions;
    [SerializeField] protected int damage;
    [SerializeField] protected int speed;
    public  override void Shoot()
    {
        for(int i = 0; i < ShootPositions.Count; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = ShootPositions[i].position;
            bullet.GetComponent<Bullet>().Init(speed, damage, ShootPositions[i].forward);
        }
    }

}
