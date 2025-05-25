using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] private RoadPlacementLogic _roadPlacement;
    [SerializeField] private float _timeLimit;
    [SerializeField] private TMP_Text _timeText;
 
    private bool _isAlive = true;

    private void Update()
    {
        
        if (_timeLimit > 0)
        {
            _timeLimit -= Time.deltaTime;
            _timeText.SetText((Mathf.Round(_timeLimit * 100) / 100).ToString());
        }
        else if (_isAlive)
        {
            FindAnyObjectByType<PlayerControl>().Explode();
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
