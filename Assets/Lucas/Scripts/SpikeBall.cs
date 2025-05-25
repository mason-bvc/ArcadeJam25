using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();

        _animator.Play("Move", -1, Random.Range(0f, 1f));
    }

}
