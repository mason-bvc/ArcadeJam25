using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GearShiftHandler;

public class UpdatedGearShift : MonoBehaviour
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
    public readonly UnityEvent<Gear> Shifted = new();
    public Gear CurrentGear { get; private set; }

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
            else if (_lastValidInput.y > 0)
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
        if (input.isPressed)
        {
            UpdateGear();
        }
    }
    private void OnBl_Stick(InputValue input)
    {
        Vector2 movement = input.Get<Vector2>();
        if (movement == Vector2.zero)
        {
            _lastValidInput = movement;
        }
        else if (_lastValidInput.x != movement.x && movement.y == 0)
        {
            _lastValidInput = movement;
        }
        else if (movement.y != _lastValidInput.y)
        {
            _lastValidInput = movement;
        }
    }
}
