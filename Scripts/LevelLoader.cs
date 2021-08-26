// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 4;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }
    IEnumerator WaitForTime()
    {


        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartScene()
    {
       // Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
    public void LoadOptionsScene()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("OptionsScene");
    }
    public void Loadlevel(int numberOfLevel)
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + numberOfLevel);
    }
    public void LoadLevelSelectionMenu()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelectionScene");
    }
    public void loadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    
    public void quitGame()
    {
        Application.Quit();
    }
}
