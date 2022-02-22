using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private int steps;
    public int stepsToCreateMoreLanes = 12;
    private int currentSteps;

    public Text stepText;
    public Text gameOverText;


    // Start is called before the first frame update
    void Awake()
    {
        levelManager = this;
    }

    public void SetSteps()
    {
        steps++;
        stepText.text = steps.ToString();
        currentSteps++;
        if(currentSteps > stepsToCreateMoreLanes)
        {
            currentSteps = 0;
            GetComponent<LevelCreator>().CreateLanes();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over \nPontos: " + steps.ToString();
        Invoke("ReloadScene", 2f);
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
