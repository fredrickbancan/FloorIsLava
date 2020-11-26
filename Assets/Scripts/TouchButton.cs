using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Customized button extension for work with android touch screens
/// </summary>
[AddComponentMenu("UI/TouchButton")]
public class TouchButton : Button
{
    /// <summary>
    /// Event for when this button is first pressed down
    /// </summary>
    private UnityEvent onButtonDown = new UnityEvent();

    /// <summary>
    /// Event for when this button is released
    /// </summary>
    private UnityEvent onButtonUp = new UnityEvent();
    /// <summary>
    /// Requred to override base button function for integration with project
    /// </summary>
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        onButtonDown.Invoke();
    }

    /// <summary>
    /// Requred to override base button function for integration with project
    /// </summary>
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        onButtonUp.Invoke();
    }

    public UnityEvent onButDown
    {
         get => onButtonDown; 
    }
    public UnityEvent onButUp
    {
        get => onButtonUp;
    }
}
