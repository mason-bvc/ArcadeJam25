using UnityEngine;

public class PlayerAndGearMediator : MonoBehaviour
{
    private PlayerControl _playerControl;
    private GearShiftHandler _gearShiftHandler;

    public void Start()
    {
        _playerControl = GetComponent<PlayerControl>();
        _gearShiftHandler = GetComponent<GearShiftHandler>();

        _gearShiftHandler.Shifted.AddListener(gear =>
        {
            switch (gear)
            {
            case GearShiftHandler.Gear.Neutral:
                _playerControl.ChangeSpeed(0);
                break;
            case GearShiftHandler.Gear.First:
                _playerControl.ChangeSpeed(45);
                break;
            case GearShiftHandler.Gear.Second:
                _playerControl.ChangeSpeed(60);
                break;
            case GearShiftHandler.Gear.Third:
                _playerControl.ChangeSpeed(75);
                break;
            case GearShiftHandler.Gear.Fourth:
                _playerControl.ChangeSpeed(90);
                break;
            }
        });
    }
}
