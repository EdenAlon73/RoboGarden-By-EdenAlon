using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject defeatCanvas;
    [SerializeField] private float waitToLoad = 4f;
    private BaseLives baseLivesScript;
    private LevelLoader levelLoader;
    private int numberOfAttackers = 0;
    private bool levelTimerFinsihed = false;

    private void Start()
    {
        baseLivesScript = FindObjectOfType<BaseLives>();
        levelLoader = FindObjectOfType<LevelLoader>();
        levelCompleteCanvas.SetActive(false);
        defeatCanvas.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinsihed && baseLivesScript.playerLives >= 1)
        {
            Debug.Log("all attackers killed");
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        {
            levelCompleteCanvas.SetActive(true);
            // insert audio getcomponent<audiosoure>().play();
            yield return new WaitForSeconds(waitToLoad);
            levelLoader.LoadNextScene();
        }
        
    }

    public void HandleLoseCondition()
    {
        defeatCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinsihed = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
