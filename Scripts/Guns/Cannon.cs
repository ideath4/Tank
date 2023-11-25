using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, IInterfaceCannon
{
    [SerializeField] protected GameObject bulletPrefab;
     public virtual void Shoot()
    {
        Debug.Log("BZZ");
    }
}
