using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : HPBase
{
    
    [SerializeField] private int _maxHP = 100;

    private void Start()
    {
        SetMaxHP(_maxHP);
        SetHP(_maxHP);
    }


    public override void AddHP(int hpToAdd)
    {
        var initHP = HP;
        HP += hpToAdd;

        if (HP > MaxHP)
        {
            HP = MaxHP;
        }

        var added = HP - initHP;

        if (added < 1)
            return;
        
        OnHeal?.Invoke(added);
    }

    public override void RemoveHP(int hpToRemove)
    {
        if (isDead)
            return;
        
        HP -= hpToRemove;

        OnDamage?.Invoke(hpToRemove);
        
        if (HP <= 0)
        {
            Death();
        }    
    }
    
    private void Death()
    {
        OnDeath?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public override void SetHP(int hp)
    {
        HP = hp;
    }

    public override void SetMaxHP(int hp)
    {
        MaxHP = hp;
    }
}
