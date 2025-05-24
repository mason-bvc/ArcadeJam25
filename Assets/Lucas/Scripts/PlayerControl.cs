using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private InputActionReference _playerMovement;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private Rigidbody _rigidbody;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxLinearVelocity = maxSpeed;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()//X is Left/Right, Y is Up/Down
    {
        Vector2 vector2Movement = _playerMovement.action.ReadValue<Vector2>();

        Debug.Log(_playerMovement.action.ReadValue<Vector2>());

        vector2Movement.y -= 0.33f;

        Vector3 movement = new Vector3(0,0,vector2Movement.y * speed);

        if (_rigidbody.linearVelocity.z + movement.z < 0)
        {
            _rigidbody.AddForce(new Vector3 (movement.x,0,0));
        }
        else
        {
            _rigidbody.AddForce(movement);
        }
        
    }
}
