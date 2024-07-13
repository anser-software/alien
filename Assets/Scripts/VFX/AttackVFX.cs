using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private LineRenderer _laserPrefab;
    
    private List<LineRenderer> _lasers = new List<LineRenderer>();
    
    private void Start()
    {
        for (int i = 0; i < _enemyDetector.MaxEnemies; i++)
        {
            _lasers.Add(Instantiate(_laserPrefab, transform));
        }
    }

    private void Update()
    {        
        var enemies = _enemyDetector.EnemiesUnderAttack;

        for (int i = 0; i < _lasers.Count; i++)
        {
            if(i < enemies.Count)
            {
                if(enemies[i] == null)
                    continue;
                
                _lasers[i].enabled = true;
                _lasers[i].SetPosition(0, transform.position);
                _lasers[i].SetPosition(1, enemies[i].transform.position);
            }
            else
            {
                _lasers[i].enabled = false;
            }
        }
    }
}
