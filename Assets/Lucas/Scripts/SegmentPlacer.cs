using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPlacer : MonoBehaviour
{
    private Vector3 _currentLocation = Vector3.zero;
    private List<GameObject> _segments = new List<GameObject>();
    private bool _isAlive = true;

    [SerializeField] private PlayerControl _player;


    private void Start()
    {
        _player.onDeath.AddListener(OnDeath);
    }


    public void PlaceSegmentWithoutRemoving(Segments newSegment)
    {
        GameObject placeSegment = Instantiate(newSegment.gameObject, _currentLocation, new Quaternion(0,0,0,0));

        if (placeSegment != null && placeSegment.GetComponent<Segments>())
        {
            placeSegment.transform.position = _currentLocation;
            placeSegment.transform.Rotate(0, 180, 0);
            _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform.position;
            _segments.Add(placeSegment);
        }
    }

    public void PlaceSegment(Segments newSegment)
    {
        if (_isAlive)
        {
            GameObject placeSegment = Instantiate(newSegment.gameObject);


            if (placeSegment != null && placeSegment.GetComponent<Segments>())
            {
                placeSegment.transform.position = _currentLocation;
                placeSegment.transform.Rotate(0, 180, 0);
                _segments.Add(placeSegment.gameObject);
                GameObject toBeRemoved = _segments[0];
                _segments.RemoveAt(0);
                Destroy(toBeRemoved);
                _currentLocation = placeSegment.GetComponent<Segments>().GetEndObject().transform.position;
            }
        }

    }

    private void OnDeath()
    {
        _isAlive = false;
    }
}
