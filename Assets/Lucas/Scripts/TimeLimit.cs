using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private TMP_Text _timeText;
 
    private void Update()
    {
        
        if (_timeLimit > 0)
        {
            _timeLimit -= Time.deltaTime;
            _timeText.SetText(_timeLimit.ToString());
        }
        else
        {
            FindAnyObjectByType<PlayerControl>().Explode();
            _timeLimit = 0;
        }
    }

    public void AddTime(float time)
    {
        _timeLimit += time;
    }
}
