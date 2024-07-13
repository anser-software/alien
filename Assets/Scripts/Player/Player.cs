using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public static Player Instance { get; private set; }
    
    public PlayerHP PlayerHP => _playerHP;
    
    [SerializeField] private PlayerHP _playerHP;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

}
