using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static readonly UnityEvent OnClickOnCircle = new();
    public static readonly UnityEvent OnUpdateTextUI = new();

    public static void SendOnClickOnCircle()
    {
        OnClickOnCircle.Invoke();
        OnUpdateTextUI.Invoke();
    }
}