using UnityEngine;

public class BombVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerControl>())
        {
            _particleSystem.Emit(250);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
