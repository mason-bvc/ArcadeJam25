using UnityEngine;

public class GearShiftHandler : MonoBehaviour
{
    public void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        Debug.Log(horizontal);
    }
}
