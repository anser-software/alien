using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPBase
{
    
    [SerializeField] private int _maxHP = 10;

    private void Start()
    {
        SetMaxHP(_maxHP);
        SetHP(_maxHP);
    }
    
    public override void AddHP(int hpToAdd)
    {
        HP += hpToAdd;
    }

    public override void RemoveHP(int hpToRemove)
    {
        if (isDead)
            return;
        
        HP -= hpToRemove;
        
        OnDamage?.Invoke(hpToRemove);
        
        DamageNumberManagerUI.Instance.ShowDamageNumber(hpToRemove, transform.position);
        
        if (HP <= 0)
        {
            Death();
        }
    }

 
    public override void SetHP(int hp)
    {
        HP = hp;
    }

    public override void SetMaxHP(int hp)
    {
        MaxHP = hp;
    }

    private void Death()
    {
        OnDeath?.Invoke();

        //Destroy(gameObject);
    }
    
}
