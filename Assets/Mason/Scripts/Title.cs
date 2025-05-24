using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Title : MonoBehaviour
{
    public readonly UnityEvent PressedStart = new();
    public readonly UnityEvent PressedQuit = new();

    public void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.enterKey.wasPressedThisFrame)
        {
            PressedStart.Invoke();
        }

        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            PressedQuit.Invoke();
        }
    }
}
