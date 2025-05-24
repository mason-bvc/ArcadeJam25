using System;
using System.Collections.Generic;
using UnityEngine;
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

    private readonly List<Key> _inputQueue = new();
    private Gear _currentGear;

    public void Update()
    {
        var keyboard = Keyboard.current;
        Key key = default;
        var newGear = _currentGear;

        bool shouldShiftBackToNeutral = false;

        shouldShiftBackToNeutral |= (_currentGear == Gear.First || _currentGear == Gear.Third) && keyboard.downArrowKey.wasPressedThisFrame;
        shouldShiftBackToNeutral |= (_currentGear == Gear.Second || _currentGear == Gear.Fourth) && keyboard.upArrowKey.wasPressedThisFrame;

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

        if (newGear != _currentGear)
        {
            Debug.Log($"Switched gear to {newGear}");
            _inputQueue.Clear();
        }

        _currentGear = newGear;
    }
}
