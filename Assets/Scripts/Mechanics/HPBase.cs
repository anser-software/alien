using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPBase : MonoBehaviour
{

    public Action OnDeath;
    public Action<int> OnDamage, OnHeal; 

    public int MaxHP { get; protected set; }
    
    public int HP { get; protected set; }
    
    public bool isDead => HP <= 0;

    public abstract void AddHP(int hpToAdd);

    public abstract void RemoveHP(int hpToRemove);

    public abstract void SetHP(int hp);
    
    public abstract void SetMaxHP(int hp);


}
