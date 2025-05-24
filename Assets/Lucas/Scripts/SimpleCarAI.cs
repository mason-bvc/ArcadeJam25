using UnityEngine;

public class SimpleCarAI : MonoBehaviour
{
    [SerializeField] private float minRandSpeed;
    [SerializeField] private float maxRandSpeed;//This should be lower than the player's max speed
    [SerializeField] private float maxSpeed;//This should be lower than the player's max speed
    private Rigidbody _rigidbody;
    private float speed = 1;//Setting it to one just incase something goes wring
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxLinearVelocity = maxSpeed;
        speed = Random.Range(minRandSpeed, maxRandSpeed);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()//X is Left/Right, Y is Up/Down
    {
        Vector3 movement = new Vector3(0, 0, 0.67f * speed);

        _rigidbody.AddForce(movement);

        if (_rigidbody.linearVelocity.z < 0)
        {
            _rigidbody.linearVelocity.Set(_rigidbody.linearVelocity.x, _rigidbody.linearVelocity.y, 0);
        }
    }
}
