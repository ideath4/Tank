using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBorder : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {

        Unit collidedUnit = collision.collider.gameObject.GetComponent<Unit>();
        if (collidedUnit != null)
        {
            collidedUnit.ApplyDamage(int.MaxValue);
        }
    }
}
