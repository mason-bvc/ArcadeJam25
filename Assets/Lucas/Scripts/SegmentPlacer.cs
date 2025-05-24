using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPlacer : MonoBehaviour
{
    private Vector3 _currentLocation = Vector3.zero;
    [SerializeField] private Segments _startSegment;
    private List<GameObject> _segments;


    public void PlaceSegmentWithoutRemoving(Segments newSegment)
    {
        GameObject placeSegment = Instantiate(newSegment.gameObject, _currentLocation, new Quaternion(0,0,0,0));

        if (placeSegment != null && placeSegment.GetComponent<Segments>())
        {
            _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform.position;
        }
    }

    public void PlaceSegment(Segments newSegment)
    {
        GameObject placeSegment = Instantiate(newSegment.gameObject, _currentLocation, new Quaternion(0, 0, 0, 0));

        if (placeSegment != null && placeSegment.GetComponent<Segments>())
        {
            _segments.Add(placeSegment);
            GameObject toBeRemoved = _segments[1];
            _segments.RemoveAt(0);
            Destroy(toBeRemoved);
           _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform.position;
        }
    }
}
