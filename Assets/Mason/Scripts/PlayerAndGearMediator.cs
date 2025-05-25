using UnityEngine;
using UnityEngine.UI;

public class PlayerAndGearMediator : MonoBehaviour
{
    private PlayerControl _playerControl;
    private GearShiftHandler _gearShiftHandler;
    [SerializeField] private Image _neutral;
    [SerializeField] private Image _1;
    [SerializeField] private Image _2;
    [SerializeField] private Image _3;
    [SerializeField] private Image _4;

    public void Start()
    {
        _playerControl = GetComponent<PlayerControl>();
        _gearShiftHandler = GetComponent<GearShiftHandler>();

        _gearShiftHandler.Shifted.AddListener(gear =>
        {
            switch (gear)
            {
                case GearShiftHandler.Gear.Neutral:
                    _neutral.enabled = true;
                    _1.enabled = false;
                    _2.enabled = false;
                    _3.enabled = false;
                    _4.enabled = false;
                    _playerControl.ChangeTurnSpeed(0);
                    _playerControl.ChangeSpeed(0);
                    _playerControl.ChangeBrakeSpeed(30);
                    _playerControl.ChangeMaxSpeed(0);
                    break;
                case GearShiftHandler.Gear.First:
                    _neutral.enabled = false;
                    _1.enabled = true;
                    _2.enabled = false;
                    _3.enabled = false;
                    _4.enabled = false;
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(30);
                    _playerControl.ChangeMaxSpeed(45);
                    break;
                case GearShiftHandler.Gear.Second:
                    _neutral.enabled = false;
                    _1.enabled = false;
                    _2.enabled = true;
                    _3.enabled = false;
                    _4.enabled = false;
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(25);
                    _playerControl.ChangeMaxSpeed(60);
                    break;
                case GearShiftHandler.Gear.Third:
                    _neutral.enabled = false;
                    _1.enabled = false;
                    _2.enabled = false;
                    _3.enabled = true;
                    _4.enabled = false;
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(20);
                    _playerControl.ChangeMaxSpeed(75);
                    break;
                case GearShiftHandler.Gear.Fourth:
                    _neutral.enabled = false;
                    _1.enabled = false;
                    _2.enabled = false;
                    _3.enabled = false;
                    _4.enabled = true;
                    _playerControl.ChangeTurnSpeed(30);
                    _playerControl.ChangeSpeed(30);
                    _playerControl.ChangeBrakeSpeed(15);
                    _playerControl.ChangeMaxSpeed(90);
                    break;
            }
        });
    }
}
