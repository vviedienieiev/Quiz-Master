using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 20f; 
    [SerializeField] float timeToShowCorrectAnswer = 5f;

    public bool isAnsweringQuestion;
    public bool loadNextQuestion; 

    float timerValue;
    public float fillFraction;
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (timerValue > 0)
        {
            if (isAnsweringQuestion)
            {
                fillFraction = timerValue/timeToCompleteQuestion;
            }
            else
            {
                fillFraction = timerValue/timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (isAnsweringQuestion)
            {
                timerValue = timeToShowCorrectAnswer;
            }
            else
            {
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
            isAnsweringQuestion = !isAnsweringQuestion;
        }
    }
}
