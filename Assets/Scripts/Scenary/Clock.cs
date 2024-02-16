using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField][Range(0, 11)] int _startHour;
    [SerializeField][Range(0, 59)] int _startMinute;
    [SerializeField] int _hourLength;
    [SerializeField] TextMeshPro _hourText;
    float _minuteLength;
    int _currentMin, _currentHr;

    private void Start()
    {
        _minuteLength = (float)_hourLength / 60f;
        _currentMin = _startMinute;
        _currentHr = _startHour;
        _hourText.text = $"{_startHour} : {_startMinute}";

        StartCoroutine(UpdateClock());
    }

    IEnumerator UpdateClock()
    {
        var min = new WaitForSeconds(_minuteLength);

        while (true)
        {
            if (_currentMin + 1 >= 60)
            { _currentHr++; _currentMin = 0; }
            else
            { _currentMin++; }
            yield return min;
            _hourText.text = _currentHr.ToString("00") + ":" + _currentMin.ToString("00");
        }
    }
}
