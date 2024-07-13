using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerMelee : MonoBehaviour
{

    public event System.Action OnAttack;
    
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _fireRate = 1F;
    [SerializeField] private int _damage;
    
    private float _lastFireTime = 0F;
    
    private void Update()
    {
        if (Player.Instance == null)
            return;
        
        if(Time.time - _lastFireTime < 1F / _fireRate)
            return;
        
        Attack();
    }

    private void Attack()
    {
        if(Vector3.Distance(Player.Instance.transform.position, transform.position) > _maxDistance)
            return;
        
        _lastFireTime = Time.time;

        Player.Instance.PlayerHP.RemoveHP(_damage);
        
        OnAttack?.Invoke();
    }
    
}
