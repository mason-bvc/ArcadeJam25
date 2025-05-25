using System;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _kmhText;

    [SerializeField]
    private TMP_Text _gearText;

    [SerializeField]
    private Transform _carTransform;

    private PlayerControl _playerControl;
    private GearShiftHandler _gearShiftHandler;

    public void Start()
    {
        _playerControl = _carTransform.GetComponent<PlayerControl>();
        _gearShiftHandler = _carTransform.GetComponent<GearShiftHandler>();
    }

    public void FixedUpdate()
    {
        _kmhText.text = string.Format("{0:000} KM/H", _playerControl.GetCurrentVelocity());
        _gearText.text = string.Format("Gear: {0}", (int)_gearShiftHandler.CurrentGear);
    }
}
