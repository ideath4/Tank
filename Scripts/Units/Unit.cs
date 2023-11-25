using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    [SerializeField] HPBar hpBar;
    public UnityEvent<float> OnChangeHP;
    public UnityEvent<Unit> OnEnemyDie;
    public int MaxHp;
    public float resist;
    protected int hp;
    public int Hp
    {
        get { return hp; }
    }
    private void Start()
    {
        Init();
    }
    protected void  Init()
    {
        hp = MaxHp;
        hpBar.Init(this);
    }
    public void ApplyDamage(int damage)
    {
        float dmg = (float)damage * resist;
        hp -= (int)dmg;
        OnChangeHP?.Invoke((float)hp / MaxHp);
        Debug.Log("HP after hit " + hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Collider collider = GetComponent<Collider>();
        if(collider != null)
        {
            collider.enabled = false;
        }

        OnEnemyDie.Invoke(this);
        Destroy(hpBar);
        Destroy(gameObject);
    }
}
