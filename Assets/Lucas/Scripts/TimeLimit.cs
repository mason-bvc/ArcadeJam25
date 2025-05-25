using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] private PlayerControl _player;
    [SerializeField] private float _timeLimit;

    private void Update()
    {
        
        if (_timeLimit > 0)
        {
            _timeLimit -= Time.deltaTime;
        }
        else
        {
            _player.Explode();
            _timeLimit = 0;
        }
    }

    public void AddTime(float time)
    {
        _timeLimit += time;
    }
}
