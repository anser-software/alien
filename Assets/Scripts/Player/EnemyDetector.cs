using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RPGCharacterAnims;
using RPGCharacterAnims.Lookups;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    
    public List<Enemy> EnemiesUnderAttack { get; private set; } = new List<Enemy>();
    
    public int MaxEnemies => _maxEnemies;
    
    [SerializeField] private float _thresholdDistance = 5f;

    [SerializeField] private float _checkInterval;

    [SerializeField] private int _maxEnemies;
    
    private float _checkTimer = 0F;
    
    private void Update()
    {
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        if (_checkTimer > 0)
        {
            _checkTimer -= Time.deltaTime;
            return;
        }
        
        var enemies = EnemyManager.Instance.Enemies;

        if (enemies.Count < 1)
            return;
        
        var closest = enemies.Where(e => Vector3.Distance(transform.position, e.transform.position) < _thresholdDistance).ToArray();
        
        var enemiesTargeted = Mathf.Min(closest.Length, _maxEnemies);
        
        EnemiesUnderAttack.Clear();
        
        for (int i = 0; i < enemiesTargeted; i++)
        {
            EnemiesUnderAttack.Add(closest[i]);
        }

        _checkTimer = _checkInterval;
    }

}
