using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{

    public event Action<int> OnLevelUp;

    public static PlayerXP Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI _levelText;
    
    [SerializeField] private Slider _xpSlider;
    
    public int XP { get; private set; } = 0;
    public int MaxXP { get; private set; } = 10;
    public int Level { get; private set; } = 1;
    
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

    private void Start()
    {
        _levelText.text = Level.ToString();
        _xpSlider.value = 0F;
    }

    public void AddXP(int xpToAdd) 
    {
        XP += xpToAdd;
        
        if (XP >= MaxXP)
        {
            MaxXP *= 2;
            XP = 0;
            Level++;
            _levelText.text = Level.ToString();
            
            OnLevelUp?.Invoke(Level);
        }
        
        _xpSlider.value = XP / (float)MaxXP;
    }

}
