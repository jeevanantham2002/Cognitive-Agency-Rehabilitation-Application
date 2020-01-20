using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottletouchingTimerScript : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Bottom")
        {
            TimerScript.stopwatch.Stop();
            TimerScript.stopwatch.Reset();
            TimerScript.WatterbottleTouches = true;
            //Placed Successfully in the cup
            //Go to scene change to a higher method called in Timer Script

           
        }

    }
}
