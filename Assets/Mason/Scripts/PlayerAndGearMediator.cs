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
                    _playerControl.ChangeTurnSpeed(0);
                    _playerControl.ChangeSpeed(0);
                    _playerControl.ChangeBrakeSpeed(30);
                    _playerControl.ChangeMaxSpeed(0);
                    break;
                case GearShiftHandler.Gear.First:
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(30);
                    _playerControl.ChangeMaxSpeed(45);
                    break;
                case GearShiftHandler.Gear.Second:
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(25);
                    _playerControl.ChangeMaxSpeed(60);
                    break;
                case GearShiftHandler.Gear.Third:
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(20);
                    _playerControl.ChangeMaxSpeed(75);
                    break;
                case GearShiftHandler.Gear.Fourth:
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(15);
                    _playerControl.ChangeMaxSpeed(90);
                    break;
            }
        });
    }
}
