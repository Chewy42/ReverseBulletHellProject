using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    //declare public variable for text mesh pro 
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //timer method
    private void InitializeTimer()
    {
        //set timer to 0
        timerText.text = "00:00";
        //start timer
        StartCoroutine(TimerCoroutine());
    }

    //timer coroutine
    private IEnumerator TimerCoroutine()
    {
        //set timer to 0
        float timer = 0f;
        //while timer is less than 60 seconds
        while (timer < 60f)
        {
            //add 1 to timer
            timer += 1f;
            //set timer text to timer
            timerText.text = timer.ToString("00:00");
            //wait 1 second
            yield return new WaitForSeconds(1f);
        }
    }
}
