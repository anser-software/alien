using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using DG.Tweening;

public class SprayAttack : MonoBehaviour
{

    [SerializeField] private EnemyDetector _enemyDetector;

    [SerializeField] private int _damage;
    [SerializeField] private float _attackInterval = 0.5f;

    private int _currentEnemyToAttack = 0;
    
    private float _timer = 0F;
    
    private void Update()
    {        
        var enemies = _enemyDetector.EnemiesUnderAttack;
        
        if(enemies.Count < 1)
            return;
        
        _timer += Time.deltaTime;
        
        if(_timer < _attackInterval / enemies.Count)
            return;
        
        _timer = 0F;
        
        if (_currentEnemyToAttack >= enemies.Count)
            _currentEnemyToAttack = 0;
        
        var target = enemies[_currentEnemyToAttack];
        
        target.HP.RemoveHP(_damage);

        if(target.HP.isDead)
            ConsumeEnemy(target);

        _currentEnemyToAttack++;
    }

    private void ConsumeEnemy(Enemy target)
    {
        target.transform.DOScale(0F, 0.2F);
        target.transform.DOMove(transform.position, 0.25F).OnComplete(() => Destroy(target.gameObject));
    }
    
}
