using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AlphaAnimUI : MonoBehaviour
{
   
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _curve;

    private TextMeshProUGUI _text;
    private float _timer;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        var value = _curve.Evaluate(_timer / _duration);
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, value);
        
        if (_timer >= _duration)
        {
            Destroy(gameObject);
        }
    }
}
