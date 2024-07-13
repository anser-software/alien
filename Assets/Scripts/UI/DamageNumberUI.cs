using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumberUI : MonoBehaviour
{

    [SerializeField] private Vector2 _offsetFromTarget;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Vector2 _movementAnim;
    
    private RectTransform _uiElement;
    private Vector3 _worldPos;
    private Camera mainCamera;
    
    private void Awake()
    {
        _uiElement = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }
    
    public void Initialize(Vector3 worldPos, int number)
    {
        _text.text = number.ToString();
        _worldPos = worldPos;
    }
    
    private void LateUpdate()
    {
        if (Player.Instance != null)
        {
            // Convert the target position to screen space
            Vector2 screenPosition = mainCamera.WorldToScreenPoint(_worldPos);

            // Set the UI element's position to the screen position
            _uiElement.position = screenPosition + _offsetFromTarget;
            
            _offsetFromTarget += _movementAnim * Time.deltaTime;
        }
    }
}
