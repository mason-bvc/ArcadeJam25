using System.Collections;
using UnityEngine;

public class SimpleCarAI : MonoBehaviour
{
    [SerializeField] private float minRandSpeed;
    [SerializeField] private float maxRandSpeed;//This should be lower than the player's max speed
    private float maxSpeed;//This should be lower than the player's max speed
    private Rigidbody _rigidbody;
    private float speed = 25;//Setting it to one just incase something goes wrong
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        maxSpeed = Random.Range(minRandSpeed, maxRandSpeed);
        _rigidbody.maxLinearVelocity = maxSpeed;
        StartCoroutine(WaitToSpawn());
    }


    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(0.1f);
        
        float zPosition = transform.position.z;
        Debug.Log(zPosition);
        transform.position = new Vector3(Random.Range(1.78f, 13.55f), 0.2f, zPosition);
        transform.parent = null;

        speed = Random.Range(minRandSpeed, maxRandSpeed);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();

        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    private void Movement()//X is Left/Right, Y is Up/Down
    {
        Vector3 movement = new Vector3(0, 0, 0.67f * speed);

        _rigidbody.AddForce(movement);
    }
}
