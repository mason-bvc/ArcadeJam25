using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Title : MonoBehaviour
{
    public readonly UnityEvent PressedStart = new();
    public readonly UnityEvent PressedQuit = new();


    private void OnBl_1(InputValue input)
    {
        Debug.Log("Done");
        if (input.isPressed)
        {
            PressedStart.Invoke();
        }
    }

    private void OnExit_Button(InputValue input)
    {
        Debug.Log("Done");
        if (input.isPressed)
        {
            PressedQuit.Invoke();
        }
    }
}
