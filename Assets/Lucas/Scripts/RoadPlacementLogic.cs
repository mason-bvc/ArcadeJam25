using System.Collections.Generic;
using UnityEngine;

public class RoadPlacementLogic : MonoBehaviour
{
    [SerializeField] private Segments _defaultSegment;
    [SerializeField] private List<Segments> _obstacleSegments;
    [SerializeField] private int _chanceForObstacle;
    [SerializeField] private SegmentPlacer _segmentPlacer;
    [SerializeField] private int _segmentsToStart;
    [SerializeField] private Segments _checkpoint;
    [SerializeField] private int _checkpointDistance;
    [SerializeField] private int _addDistance;
    private int _currentDistance = 0;


    private void Awake()
    {
        for (int i = 0; i < _segmentsToStart / 2; i++)
        {
            _segmentPlacer.PlaceSegmentWithoutRemoving(_defaultSegment);
        }

        for (int i = 0; i < _segmentsToStart / 2; i++)
        {
            if (Random.Range(1, _chanceForObstacle) == 1)
            {
                _segmentPlacer.PlaceSegmentWithoutRemoving(_obstacleSegments[Random.Range(0, _obstacleSegments.Count)]); 
            }
            else
            {
                _segmentPlacer.PlaceSegmentWithoutRemoving(_defaultSegment);
            }
        }
    }

    public void PlaceSegment()
    {
        Segments chosenSegment = _defaultSegment;
        if (_currentDistance >= _checkpointDistance)
        {
            chosenSegment = _checkpoint;
            _currentDistance = 0;
            _checkpointDistance += _addDistance;
        }
        else if (Random.Range(1, _chanceForObstacle) == 1)
        {
            chosenSegment = _obstacleSegments[Random.Range(0, _obstacleSegments.Count)];
        }

        _segmentPlacer.PlaceSegment(chosenSegment);
        _currentDistance += 1;
    }

    public void IncreaseChancesForObstacles()
    {
        if (_chanceForObstacle > 2)
        {
            _chanceForObstacle -= 1;
        }
    }


}
