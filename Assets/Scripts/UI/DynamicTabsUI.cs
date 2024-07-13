using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DynamicTabsUI : MonoBehaviour
{

    [SerializeField] private TabUI _mainTab;
    [SerializeField] private TabUI[] _tabs;
    [SerializeField] private float _animDuration = 0.5f;
    
    [SerializeField] private Color _activeTabColor;
    
    
    private void Start()
    {
        for (int i = 0; i < _tabs.Length; i++)
        {
            var i1 = i;
            _tabs[i].TabButton.onClick.AddListener(() => { SetTabActive(i1); });
        }
        
        _mainTab.TabButton.onClick.AddListener(SetMainTabActive);
        
        SetMainTabActive();
    }

    private void SetMainTabActive()
    {
        SetTabActive(-1);
        
        _mainTab.Tab.SetActive(true);
    }

    private void SetTabActive(int index)
    {
        _mainTab.Tab.SetActive(false);

        for (int i = 0; i < _tabs.Length; i++)
        {
            var tab = _tabs[i];
            
            tab.Tab.SetActive(i == index);
            
            tab.TabButton.image.color = i == index ? _activeTabColor : Color.white;
        }
    }

}

[Serializable]
public class TabUI
{
    public Button TabButton;
    public GameObject Tab;
}