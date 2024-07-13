using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public static EnemyManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
    
    public void RegisterEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
    
    public void UnregisterEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }
    
}
