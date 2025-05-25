using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] private PlayerControl _player;
    [SerializeField] private RoadPlacementLogic _roadPlacement;
    [SerializeField] private float _timeLimit;
    private bool _isAlive = true;

    private void Update()
    {
        
        if (_timeLimit > 0)
        {
            _timeLimit -= Time.deltaTime;
        }
        else if (_isAlive)
        {
            _player.Explode();
            _timeLimit = 0;
            _isAlive = false;
        }
    }

    public void AddTime(float time)
    {
        _timeLimit += time;
        _roadPlacement.IncreaseChancesForObstacles();
    }
}
