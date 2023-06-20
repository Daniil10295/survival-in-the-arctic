using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private int dayLenght;
    [SerializeField] private TextMeshProUGUI text;
    private int day;
    private int hour;
    private int displayminute;
    private int minute;
    private Light2D light;
    private float wait;
    private float minIntensity;
    private float maxIntensity;
    private bool _isDay = true;

    private void Start()
    {
        light = GetComponent<Light2D>();
        day = PlayerPrefs.GetInt("day", 0);
        hour = PlayerPrefs.GetInt("hour", 0);
        minute = PlayerPrefs.GetInt("minute", 0);
        displayminute = PlayerPrefs.GetInt("displayMinute", 0);
        _isDay = PlayerPrefs.GetInt("isDay", 0) == 1;
        wait = dayLenght / 1440f;
        minIntensity = .2f;
        maxIntensity = .8f;
        StartCoroutine(TimeLight());
    }

    private IEnumerator TimeLight()
    {
        light.intensity = minIntensity;
        while (true)
        {
            minute = _isDay ? minute - 1 : minute + 1;
            displayminute += 1;
            float minute01 = Mathf.InverseLerp(0, 720, minute);
            
            light.intensity = Mathf.Lerp(minIntensity, maxIntensity, minute01);
            
            if (minute == 720)
            {
                _isDay = true;
                PlayerPrefs.SetInt("isDay", 1);
            }
            if (minute == 0)
            {
                _isDay = false;
                PlayerPrefs.SetInt("isDay", 0);
            }
            if (displayminute >= 60)
            {
                displayminute = 0;
                hour += 1;
                PlayerPrefs.SetInt("hour", hour);
                if (hour >= 24)
                {
                    hour = 0;
                    day += 1;
                    PlayerPrefs.SetInt("day", day);
                }
            }
            
            PlayerPrefs.SetInt("minute", minute);
            //PlayerPrefs.SetInt("displayMinute", displayminute);
            text.text = $"{hour:00}:{displayminute:00}\nDay : {day}";
            yield return new WaitForSeconds(wait);
        }
    }
}