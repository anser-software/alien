using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Joystick _joystick;
    [SerializeField] private AnimateSpider _animateSpider;
    
    private void Update()
    {
        var dir = new Vector3(-_joystick.Direction.x, 0F, -_joystick.Direction.y);
        _animateSpider.SetTargetDirection(dir);
    }
}
