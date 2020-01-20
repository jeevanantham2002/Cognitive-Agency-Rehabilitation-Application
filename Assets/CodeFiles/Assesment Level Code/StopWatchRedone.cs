using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class StopWatchRedone : MonoBehaviour
{
    public static Stopwatch stopwatch = new Stopwatch();
    [SerializeField] private Text UiText;
    public static long currentime;
    public static long assesmentvalue;
    public  GameObject RightWall;
    public  GameObject LeftWall;
    public  GameObject TimeWall;
    public static bool AssesmentTestComplete = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentime = stopwatch.ElapsedMilliseconds/1000;
        UiText.text = "" + currentime;
        assesmentvalue = currentime;

    }

   public  void StartStopWatch (){
        Invoke("TurnRoomRed", 1);
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
        Invoke("TurnRoomGreen", 1);
    }
    void TurnRoomGreen()
    {
        RightWall.GetComponent<Renderer>().material.color = Color.green;
        LeftWall.GetComponent<Renderer>().material.color = Color.green;
        TimeWall.GetComponent<Renderer>().material.color = Color.green;
        stopwatch.Start(); //Starts Stopwatch
    }
}
