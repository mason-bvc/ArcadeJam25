using UnityEngine;

public class NeedleFollow : MonoBehaviour
{
    [SerializeField] private GameObject _endPointGameObject;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        Vector2 targetDirection = _endPointGameObject.transform.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}
