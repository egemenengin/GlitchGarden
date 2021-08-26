// Egemen Engin 
// https://github.com/egemenengin

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    AttackerSpawner[] spawners;
    GameObject winLabel;
    GameObject loseLabel;
    int numberOfAttacker = 0;
    bool timerFinished = false;
    float waitLoadTime = 5f;
    bool Lost = false;
    private void Awake()
    {
        levelDifficulty(PlayerPrefsController.getDifficulty());
        GetComponent<AudioSource>().volume = PlayerPrefsController.getVolume();

    }
    private void Start()
    {

        winLabel = GameObject.Find("LevelCompleteCanvas");
        loseLabel = GameObject.Find("LevelLostCanvas");
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    private void Update()
    {
        
         if (winLabel.activeSelf && numberOfAttacker<=0 && !Lost)
         {
             winLabel.transform.position = Vector3.MoveTowards(winLabel.transform.position, new Vector2(5,3), 3*Time.deltaTime);
             
         }
        if (Lost)
        {
            loseLabel.transform.position = Vector3.MoveTowards(loseLabel.transform.position, new Vector2(5, 3), 3 * Time.deltaTime);
            //STOP EVERYTHING
            /* if(loseLabel.transform.position.x == 5)
            {
                Time.timeScale = 0;
            }*/
        }
     
        }
   
    public void AttackerKilled()
    {
        int temp = 0;
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            temp += spawner.transform.childCount;
        }
        numberOfAttacker = temp-1;
        if (timerFinished)
        {
            foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
            {
                spawner.stopSpawning();
            }
        }
        if(numberOfAttacker<=0 && timerFinished)
        {
            StartCoroutine(HandleWithWinCondition());
        }

    }
    IEnumerator HandleWithWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
       // winLabel.GetComponent<Animation>().enabled = true;
        
        FindObjectOfType<DefenderSpawner>().setDefender(null);
        
        foreach (Defender defender in FindObjectsOfType<Defender>())
        {
            if (defender.GetComponent<Animator>())
                defender.GetComponent<Animator>().enabled = false;
        }
        
        
        yield return new WaitForSeconds(waitLoadTime);
       // FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void levelTimerFinished()
    {
        timerFinished = true;
    }
    public void HandleWithLoseCondition()
    {
        Lost = true;
        loseLabel.SetActive(true);
        
        FindObjectOfType<DefenderSpawner>().setDefender(null);
        
        //DEFENDERS STOP MOVE
        foreach (Defender defender in FindObjectsOfType<Defender>())
        {
            if (defender.GetComponent<Animator>())
                defender.GetComponent<Animator>().enabled = false;
        }
        //SPAWNERS STOP SPAWN
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.stopSpawning();
        }
        //ATTACKERS STOP MOVING 
        foreach (Attacker remainingAttacker in FindObjectsOfType<Attacker>())
        {
            if (remainingAttacker.GetComponent<Animator>())
                remainingAttacker.GetComponent<Animator>().enabled = false;
            remainingAttacker.setMovementSpeed(0);
        }
    }
    public void levelDifficulty(float difficulty)
    {
        if (difficulty == 0f)
        {
            FindObjectOfType<HealthDisplay>().setCurrentHealth(0);
        }
        if (difficulty == 1f)
        {
            FindObjectOfType<HealthDisplay>().setCurrentHealth(1);
        }
        if (difficulty == 2f)
        {
            FindObjectOfType<HealthDisplay>().setCurrentHealth(2);
        }
        if (difficulty == 3f)
        {
            FindObjectOfType<HealthDisplay>().setCurrentHealth(3);

        }
        if (difficulty == 4f)
        {
            FindObjectOfType<HealthDisplay>().setCurrentHealth(4);

        }
       
    }
}
