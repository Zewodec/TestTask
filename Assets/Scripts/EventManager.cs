using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static readonly UnityEvent OnClickOnCircle = new();
    public static readonly UnityEvent OnUpdateTextUI = new();
    public static readonly UnityEvent OnLevelChange = new();

    /// <summary>
    /// Invoke actions when click on circle.
    /// </summary>
    public static void SendOnClickOnCircle()
    {
        OnClickOnCircle.Invoke();
        OnUpdateTextUI.Invoke();
    }

    /// <summary>
    /// Invoke actions when level change.
    /// </summary>
    public static void SendOnLevelChange()
    {
        OnLevelChange.Invoke();
    }
}