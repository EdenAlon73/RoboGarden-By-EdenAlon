using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Length Of Level In Seconds")]
    [SerializeField] private float levelTime = 10;

    private Slider slider;
    private LevelController levelController;
    private bool triggeredLevelFinished = false;

    private void Start()
    {
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();

    }

    private void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            levelController.LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
