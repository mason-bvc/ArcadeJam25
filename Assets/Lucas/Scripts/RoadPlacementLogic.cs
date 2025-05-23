using System.Collections.Generic;
using UnityEngine;

public class RoadPlacementLogic : MonoBehaviour
{
    [SerializeField] private Segments _defaultSegment;
    [SerializeField] private List<Segments> _obstacleSegments;
    [SerializeField] private int _chanceForObstacle;
    [SerializeField] private int _amountForDecrease;
    [SerializeField] private SegmentPlacer _segmentPlacer;
    [SerializeField] private int _amountToStart;

    private int _amountTillReduced = 10;

    private void Awake()
    {
        _amountTillReduced = _amountForDecrease;
        for (int i = 0; i < _amountToStart/2; i++)
        {
            _segmentPlacer.PlaceSegmentWithoutRemoving(_defaultSegment);
        }

        for (int i = 0; i < _amountToStart / 2; i++)
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

        if (Random.Range(1, _chanceForObstacle) == 1)
        {
            chosenSegment = _obstacleSegments[Random.Range(0, _obstacleSegments.Count)];
        }
        _amountTillReduced -= 1;

        if (_amountTillReduced < 1 && _chanceForObstacle > 2)
        {
            _chanceForObstacle -= 1;
            _amountTillReduced = _amountForDecrease;
        }

        _segmentPlacer.PlaceSegment(chosenSegment);
    }


}
