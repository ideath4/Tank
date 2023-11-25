using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    [SerializeField] int damage = 20;
    PlayerController target;
    NavMeshAgent agent;
    Coroutine attackCor;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    new void Init()
    {
        base.Init();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(AICoroutine());
    }
    IEnumerator AICoroutine()
    {
        while (true)
        {
            if (target == null)
            {
                target = FindObjectOfType<PlayerController>();
            }
            else
            {
                agent.SetDestination(target.transform.position);
                while (agent.pathPending)
                    yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(.2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Unit collidedUnit = collision.collider.gameObject.GetComponent<Unit>();
        if (collidedUnit != null)
        {
            collidedUnit.ApplyDamage(damage);
            Die();
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
