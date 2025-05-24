using UnityEngine;

public class SegmentDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl player = other.gameObject.GetComponent<PlayerControl>();
        if (player != null)
        {
            FindFirstObjectByType<RoadPlacementLogic>().PlaceSegment();
            //Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }
}
