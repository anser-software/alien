using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberManagerUI : MonoBehaviour
{
    
    public static DamageNumberManagerUI Instance { get; private set; }
    
    [SerializeField] private DamageNumberUI _damageNumberUIPrefab;
    
    private void Awake()
    {
        Instance = this;
    }

    public void ShowDamageNumber(int number, Vector3 worldPos)
    {
        var damageNumberUI = Instantiate(_damageNumberUIPrefab, transform);
        damageNumberUI.Initialize(worldPos, number);
    }

}
