using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Custom Switch Toggle UI Script
/// developed using Unity 2021 LTS
/// yusuf.buyruk@ghd.com
/// </summary>
public class SwitchToggle : MonoBehaviour
{
    // Toggle Button components
    // sprite, colors
    [SerializeField] public RectTransform uiHandleRectTransform;
    [SerializeField] public Color backgroundActiveColor;
    [SerializeField] public Color handleActiveColor;

    // Toggle Button components
    private Image _backgroundImage, _handleImage;
    private Color _backgroundDefaultColor, _handleDefaultColor;
    private Toggle _toggle;
    private Vector2 _handlePosition;

    void Awake()
    {
        // Built-in Toggle component
        _toggle = GetComponent<Toggle>();

        // Handle Position
        _handlePosition = uiHandleRectTransform.anchoredPosition;

        // Background Image
        _backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        
        // Handle Image
        _handleImage = uiHandleRectTransform.GetComponent<Image>();

        // Background Default Color
        _backgroundDefaultColor = _backgroundImage.color;

        // Handle Default Color
        _handleDefaultColor = _handleImage.color;

        // Add Listener Event += OnSwitch
        _toggle.onValueChanged.AddListener(OnSwitch);

        // Initial Value
        OnSwitch(_toggle.isOn);
    }

    void OnDestroy()
    {
        // Remove Listener Event -= OnSwitch
        _toggle.onValueChanged.RemoveListener(OnSwitch);
    }

    // OnValueChanged
    void OnSwitch(bool on)
    {
        // Handle Image Position
        uiHandleRectTransform.anchoredPosition = on ? _handlePosition * -1 : _handlePosition;

        // Background Image Color
        _backgroundImage.color = on ? backgroundActiveColor : _backgroundDefaultColor;

        // Handle Image Color
        _handleImage.color = on ? handleActiveColor : _handleDefaultColor;
    }

}
