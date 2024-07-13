using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    
    public static HealthBarManager Instance { get; private set; }
    
    [SerializeField] private HealthBarUI _healthBarPrefabUI;

    private void Awake()
    {
        Instance = this;
    }

    public void GetHealthBar(HPBase hpBase)
    {
        var healthBarUI = Instantiate(_healthBarPrefabUI, transform);
        healthBarUI.SetTarget(hpBase);
    }
    
}
