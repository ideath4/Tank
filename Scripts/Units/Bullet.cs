using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime = 10;
    float speed = 5;
    int damage;
    Vector3 direction;
    public void Init(float _speed, int _damage, Vector3 _direction)
    {
        damage = _damage;
        speed = _speed;
        direction = Vector3.Normalize(_direction);
        Destroy(gameObject, lifeTime) ;
    }
    void FixedUpdate()
    {
        transform.position = transform.position + direction * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Unit target = collision.collider.gameObject.GetComponent<Unit>();
        if(target != null)
        {
            target.ApplyDamage(damage);
            Destroy(gameObject);
        }
        

    }
}
