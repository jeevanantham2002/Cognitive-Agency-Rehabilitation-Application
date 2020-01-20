using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour
{
    public static int Score=0;
    public int ScoreFromTheStartOfTheLevel;
    public Text ScoreDisplay;
    //public static ScoringScript random = new ScoringScript();
    // Start is called before the first frame update
    void Start()
    {
        //assessment should store the level we go to and on start of scoring script we compare this scene name to starting scene name if they match, add that levels score to our own

        if (AssesmentToLevel.assignedtoalevel == false)
        {
            Score = ScoreFromTheStartOfTheLevel;
            AssesmentToLevel.assignedtoalevel = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
       
       
    }

    void DisplayScore()
    {
        ScoreDisplay.text = "Score: " + Score;

    }

    

    /*void WonGame()
    {

        if () {
            SceneManager.LoadScene("WonGame");
        }

    //Add the final Score to Present Winning the Game
    }*/ 
}

