using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottleTouchingScript : MonoBehaviour
{
    private bool delayedCheck = false;
    private bool invokeOnce = false;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Bottom")
        {
           // Debug.Log("Hi");
            //if (!invokeOnce)
            //{
            //   // Debug.Log("I got invoked");
            //    Invoke("Timedelaymethod", 2f); //Make sure it is lying down on the coaster not just lucky bounce in 
            //    invokeOnce = true;
            //}
            //if (collision.gameObject.name == "Bottom" && delayedCheck == true)
            //{
            //    //if I get here stop the stopwatch and subtract 2 seconds for the invoke to get an accurate time
            //    //Debug.Log("got second");
            //    StopWatchRedone.stopwatch.Stop();
            //    StopWatchRedone.AssesmentTestComplete = true;
            //    delayedCheck = false;
            //    invokeOnce = false;
            //} else
            //{
            //    delayedCheck = false;
            //    invokeOnce = false;
            //}
            StopWatchRedone.stopwatch.Stop();
            StopWatchRedone.AssesmentTestComplete = true;
        }

    }

    public void Timedelaymethod()
    {
        delayedCheck = true;
    }
}
