using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public static Stopwatch stopwatch = new Stopwatch();
    [SerializeField] public Text TimeTextField;
    [SerializeField] public Text GameWonOrNotTextField;
    [SerializeField] public Text LevelName;
    [SerializeField] public Text LivesLeft;
    static bool gameOver;
    //public static TimerScript random = new TimerScript();


    public static long currentime;
    public GameObject RightWall;
    public GameObject LeftWall;
    public GameObject TimeWall;
    public long gameovertime;
    public string LowerLevel;
    public string NextLevel;
    public static bool WatterbottleTouches;
    public static bool SceneComplete;
    public static string CurrentScene;
    public static int lives = 3;
    public static int NumberOfTotalAttempts = 0;
    public static double GreenWallDelay = (100 - NumberOfTotalAttempts) / 100;
    // Start is called before the first frame update on every scene
    void Start() 
    {
        NumberOfTotalAttempts= PlayerPrefs.GetInt("Attempts"); //Sets the count of the number of atttempts at the start of each scene from the PLayerPrefs File
        CurrentScene = SceneManager.GetActiveScene().name;
        LevelName.text = CurrentScene;
        SceneComplete = false;
        currentime = 0;
        TimeTextField.text = "" + currentime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            TimeTextField.text = "";
            GameWonOrNotTextField.text = "YOU LOST";
        }
        else
        {
            DisplayTime();
            SceneChangeToLowerLevel();
            SceneChangeToHigherLevel();
            DisplayLives();
        }

    }

    void DisplayTime()
    {
        currentime = stopwatch.ElapsedMilliseconds / 1000;
        TimeTextField.text = "" + currentime;

    }


    public void StartStopWatch()
    {
        Invoke("TurnRoomRed", 1);
    }

    void SceneChangeToLowerLevel()
    {
        if (currentime > gameovertime)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            ScoringScript.Score -= 150;
            lives = lives - 1;
            SceneManager.LoadScene(LowerLevel);
            TimerScript.EndGame();

        }
    }
    void SceneChangeToHigherLevel()
    {
        if (SceneComplete)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            UnityEngine.Debug.Log(CurrentScene);
            ScoringScript.Score += 100;
            if (CurrentScene == "Level 7")
            {
                TimeTextField.text = "";
                GameWonOrNotTextField.text = "YOU WON";
                SceneComplete = false;
                NumberOfTotalAttempts = NumberOfTotalAttempts + 1;
                UpdateGamePlayCount();
            }
            else
            {
                // SceneComplete = false; 
                SceneManager.LoadScene(NextLevel);
            }
        }
    }


    void TurnRoomRed()
    {
        RightWall.GetComponent<Renderer>().material.color = Color.red;
        LeftWall.GetComponent<Renderer>().material.color = Color.red;
        TimeWall.GetComponent<Renderer>().material.color = Color.red;
        Invoke("TurnRoomYellow", 1);
    }
    void TurnRoomYellow()
    {
        RightWall.GetComponent<Renderer>().material.color = Color.yellow;
        LeftWall.GetComponent<Renderer>().material.color = Color.yellow;
        TimeWall.GetComponent<Renderer>().material.color = Color.yellow;
        Invoke("TurnRoomGreen", (float)GreenWallDelay);// Add the Delay Here
    }
    void TurnRoomGreen()
    {
        RightWall.GetComponent<Renderer>().material.color = Color.green;
        LeftWall.GetComponent<Renderer>().material.color = Color.green;
        TimeWall.GetComponent<Renderer>().material.color = Color.green;
        stopwatch.Start(); //Starts Stopwatch and ends in WaterBttleTimerScript
    }

    public static void EndGame()
    { //EndGame Handled in Score Script

        if (lives == 0)
        {
            gameOver = true;

        }
        NumberOfTotalAttempts = NumberOfTotalAttempts + 1;
        UpdateGamePlayCount();


    }

    public void DisplayLives()
    {
        LivesLeft.text = "Lives Left: " + lives;
    }
    public void isSceneComplete()
    {
        if (WatterbottleTouches)
        {
            SceneComplete = true;
        }
    }
    void OnApplicationQuit()
    {
        UnityEngine.Debug.Log("User Played " + NumberOfTotalAttempts + " attempts");
        UpdateGamePlayCount();
    }

    public static void UpdateGamePlayCount()
    {
        PlayerPrefs.SetInt("Attempts", NumberOfTotalAttempts);
    }
}

