using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField] private GameObject _visual;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Vector2 _offsetFromTarget;
    
    private RectTransform _uiElement;
    private Camera mainCamera;
    private HPBase _hpBase;

    private void Start()
    {
        mainCamera = Camera.main;
        _uiElement = GetComponent<RectTransform>();
    }
    
    public void SetTarget(HPBase target)
    {
        _hpBase = target;
        _hpBase.OnDeath += OnTargetDeath;
    }

    private void Update()
    {
        _slider.value = _hpBase.HP / (float)_hpBase.MaxHP;
        _text.text = _hpBase.HP.ToString();
        
        _visual.SetActive(_hpBase.HP < _hpBase.MaxHP);
        _slider.targetGraphic.enabled = _hpBase.HP < _hpBase.MaxHP;
    }

    private void OnTargetDeath()
    {
        _hpBase.OnDeath -= OnTargetDeath;
        Destroy(gameObject);
    }
    
    private void LateUpdate()
    {
        if (_hpBase != null)
        {
            Vector3 targetPosition = _hpBase.transform.position;

            Vector2 screenPosition = mainCamera.WorldToScreenPoint(targetPosition);

            _uiElement.position = screenPosition + _offsetFromTarget;
        }
    }
    
}
