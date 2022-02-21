using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private int steps;
    public int stepsToCreateMoreLanes = 12;
    private int currentSteps;

    public Text stepText;


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
}
