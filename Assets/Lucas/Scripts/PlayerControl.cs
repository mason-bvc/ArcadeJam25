using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private InputActionReference _playerMovement;
    [SerializeField] private float _speed;
    [SerializeField] private float _breakSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _laneSwitchSpeed;
    [SerializeField] private AudioSource _motorSound;
    [SerializeField] private AudioSource _explosionSound;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private CinemachineCamera _cam;
    [SerializeField] private Collider _triggerer;
    public UnityEvent onDeath;

    private Rigidbody _rigidbody;
    private bool _isAlive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxLinearVelocity = _maxSpeed;
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            Movement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isAlive && other.gameObject.CompareTag("Obstacle"))
        {
            Explode();
        }
    }

    public void Explode()
    {
        Game.PlayerDied.Invoke();
        Debug.Log("Collision happened");
        _isAlive = false;
        onDeath.Invoke();
        _explosionSound.Play();
        _motorSound.Stop();
        _explosion.Emit(500);
        _rigidbody.maxLinearVelocity = 10000;
        _rigidbody.freezeRotation = false;
        _rigidbody.AddForce(0, Mathf.Abs(GetCurrentVelocity()) * 2, 0);
        _cam.gameObject.SetActive(false);
        _triggerer.enabled = false;
    }

    private void Movement()//X is Left/Right, Y is Up/Down
    {
        Vector2 vector2Movement = _playerMovement.action.ReadValue<Vector2>();

        //Debug.Log(_playerMovement.action.ReadValue<Vector2>());

        vector2Movement.y -= 0.33f;

        Vector3 movement = new Vector3(0, 0, 0);

        if (vector2Movement.y < 0)
        {
            movement = new Vector3(vector2Movement.x * _laneSwitchSpeed, 0, vector2Movement.y * _breakSpeed);
        }
        else
        {
            movement = new Vector3(vector2Movement.x * _laneSwitchSpeed, 0, vector2Movement.y * _speed);
        }



        if (GetCurrentVelocity() + movement.z < 0)
        {
            _rigidbody.AddForce(new Vector3 (movement.x,0,0));
        }
        else
        {
            _rigidbody.AddForce(movement);
            _motorSound.pitch = (GetCurrentVelocity()+10)/25;
        }
        _motorSound.volume = GetCurrentVelocity()/10;

    }

    public float GetCurrentVelocity()
    { return _rigidbody.linearVelocity.z; }

    public void ChangeMaxSpeed(float newSpeed)
    {
        _maxSpeed = newSpeed;
        _rigidbody.maxLinearVelocity = _maxSpeed;
    }

    public void ChangeSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    public void ChangeTurnSpeed(float newSpeed)
    {
        _laneSwitchSpeed = newSpeed;
    }

    public void ChangeBrakeSpeed(float newSpeed)
    {
        _breakSpeed = newSpeed;
    }

}
