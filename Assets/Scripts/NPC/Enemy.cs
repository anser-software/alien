using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyHP HP => _hp;
    
    [SerializeField] private EnemyHP _hp;
    
    private void Start()
    {
        EnemyManager.Instance.RegisterEnemy(this);
        
        HealthBarManager.Instance.GetHealthBar(_hp);
        _hp.OnDeath += OnDeath;
    }
    
    private void OnDestroy()
    {
        EnemyManager.Instance.UnregisterEnemy(this);
        _hp.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        
    }

}
