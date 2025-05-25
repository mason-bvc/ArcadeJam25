using UnityEngine;
[RequireComponent(typeof(Collider))]
public class AddTime : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    [SerializeField] private float timeToAdd;
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl player = other.gameObject.GetComponent<PlayerControl>();
        if (player != null)
        {
            FindFirstObjectByType<TimeLimit>().AddTime(timeToAdd);
            //Debug.Log("Destroyed");
            GetComponent<AudioSource>().Play();
            GetComponent<Collider>().enabled = false;
        }
    }
}
