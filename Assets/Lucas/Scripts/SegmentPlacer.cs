using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPlacer : MonoBehaviour
{
    private Transform _currentLocation;
    [SerializeField] private Segments _startSegment;
    private List<GameObject> _segments;

    private void Start()
    {
        GameObject placeSegment = Instantiate(_startSegment.gameObject, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform;
        _segments.Add(placeSegment);
    }

    public void PlaceSegmentWithoutRemoving(Segments newSegment)
    {
        GameObject placeSegment = Instantiate(newSegment.gameObject, _currentLocation.position, _currentLocation.rotation);

        if (placeSegment != null && placeSegment.GetComponent<Segments>())
        {
            _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform;
        }
    }

    public void PlaceSegment(Segments newSegment)
    {
        GameObject placeSegment = Instantiate(newSegment.gameObject,_currentLocation.position,_currentLocation.rotation);

        if (placeSegment != null && placeSegment.GetComponent<Segments>())
        {
            _segments.Add(placeSegment);
            GameObject toBeRemoved = _segments[1];
            _segments.RemoveAt(0);
            Destroy(toBeRemoved);
           _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform;
        }
    }
}
