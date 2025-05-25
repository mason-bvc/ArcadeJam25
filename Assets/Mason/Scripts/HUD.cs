using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField]
    private Transform _carTransform;

    [SerializeField] private Slider _slider;

    private PlayerControl _playerControl;
    private GearShiftHandler _gearShiftHandler;

    public void Start()
    {
        _playerControl = _carTransform.GetComponent<PlayerControl>();
    }

    public void FixedUpdate()
    {
        _slider.value = _playerControl.GetCurrentVelocity()/90;
    }
}
