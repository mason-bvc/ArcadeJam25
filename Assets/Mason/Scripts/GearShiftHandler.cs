using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GearShiftHandler : MonoBehaviour
{
    public enum Gear
    {
        Neutral,
        First,
        Second,
        Third,
        Fourth,
    }

    private Vector2 _lastValidInput = Vector2.zero;

    //private readonly List<Key> _inputQueue = new();

    public readonly UnityEvent<Gear> Shifted = new();
    public Gear CurrentGear { get; private set; }

    /*public void Update()
    {
        var keyboard = Keyboard.current;
        Key key = default;
        var newGear = CurrentGear;

        bool shouldShiftBackToNeutral = false;

        shouldShiftBackToNeutral |= (CurrentGear == Gear.First || CurrentGear == Gear.Third) && keyboard.downArrowKey.wasPressedThisFrame;
        shouldShiftBackToNeutral |= (CurrentGear == Gear.Second || CurrentGear == Gear.Fourth) && keyboard.upArrowKey.wasPressedThisFrame;

        if (shouldShiftBackToNeutral)
        {
            newGear = Gear.Neutral;
        }

        if (_inputQueue.Count == 0)
        {
            if (keyboard.leftArrowKey.wasPressedThisFrame)
            {
                key = Key.LeftArrow;
            }
            else if (keyboard.rightArrowKey.wasPressedThisFrame)
            {
                key = Key.RightArrow;
            }
        }
        else if (_inputQueue.Count == 1)
        {
            if (keyboard.upArrowKey.wasPressedThisFrame)
            {
                key = Key.UpArrow;
            }
            else if (keyboard.downArrowKey.wasPressedThisFrame)
            {
                key = Key.DownArrow;
            }
        }

        if (key != Key.None)
        {
            _inputQueue.Add(key);
        }

        if (_inputQueue.Count == 2)
        {
            if (_inputQueue[0] == Key.LeftArrow)
            {
                if (_inputQueue[1] == Key.UpArrow)
                {
                    newGear = Gear.First;
                }
                else if (_inputQueue[1] == Key.DownArrow)
                {
                    newGear = Gear.Second;
                }
            }
            else if (_inputQueue[0] == Key.RightArrow)
            {
                if (_inputQueue[1] == Key.UpArrow)
                {
                    newGear = Gear.Third;
                }
                else if (_inputQueue[1] == Key.DownArrow)
                {
                    newGear = Gear.Fourth;
                }
            }
        }

        if (newGear != CurrentGear)
        {
            Debug.Log($"Switched gear to {newGear}");
            _inputQueue.Clear();
        }

        CurrentGear = newGear;
        Shifted.Invoke(newGear);
    }*/

    private void UpdateGear()
    {
        var newGear = CurrentGear;

        if (_lastValidInput == Vector2.zero)
        {
            newGear = Gear.Neutral;
        }
        else if (_lastValidInput.x < 0)
        {
            if (_lastValidInput.y > 0)
            {
                newGear = Gear.First;
            }
            else if (_lastValidInput.y < 0)
            {
                newGear = Gear.Second;
            }
        }
        else if (_lastValidInput.x > 0)
        {
            if (_lastValidInput.y > 0)
            {
                newGear = Gear.Third;
            }
            else if (_lastValidInput.y < 0)
            {
                newGear = Gear.Fourth;
            }
        }

        if (newGear != CurrentGear)
        {
            Debug.Log($"Switched gear to {newGear}");
        }

        CurrentGear = newGear;
        Shifted.Invoke(newGear);
    }

    private void OnBl_1(InputValue input)
    {
        Debug.Log("Done");
        if (input.isPressed)
        {
            UpdateGear();
        }
    }
    private void OnBl_Stick(InputValue input)
    {
        Vector2 movement = input.Get<Vector2>();
        //Debug.Log(movement);
        if (movement.x == 0 && movement.y != 0)
        {
            //Nothing lmao
        }
        else if (movement.x != 0 && movement.y == 0)
        {

        }
        else
        {
            _lastValidInput = movement;
        }
        Debug.Log(_lastValidInput);

    }

}
