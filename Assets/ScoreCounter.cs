/*********************************************************************
 * 
 * 
 * 
 * 
 * 
 * 
 *********************************************************************/

using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreCounter : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("UI element where our score is displayed")]
    public Text scoreUI;

    [Tooltip("UI element that displays the increase or decrease of our score")]
    public Text scoreUiIndicator;

    [Tooltip("UI element displaying our potential bonus score")]
    public Text bonusUI;

    [Tooltip("Canvas that contains our bonus point system display")]
    public Canvas bonussystem;

    int scorelist = 0; //a list of scores being held for use in update
    double dignum = 0; //number of digits in displayscore
    static int score = 0;  //score that we are adding to our system
    int displayscore = 0; //score to be displayed on the UI
    int decayscore = 0; //score to be displayed when decay system is functioning

    [Header("Score Management")]
    [Tooltip("Base amount of points to be earned under base scoring conditions")]
    public int basescore = 500;

    [Tooltip("Score amount to start at when engaging the bonus point system")]
    public int decaystart = 5000; //score to start at when using decay system

    [Tooltip("The rate at which the bonus score decreases when the player has not met the win condition")]
    public float decayrate = 500; //rate at which the score decreases, multiply this by Time.Deltatime in the update

    [Tooltip("The rate at which our score increases or decreases on the display when changing")]
    public float displayrate = 5; // rate at which the score decreases, multiply this by Time.Deltatime in the update, multiuply this by 10^dignum

    bool decayUpdater = false;
    bool decayCondition = false;
    static bool staticUpdater = false;
    bool comeInFromDecay = false;
    bool comeInFromRandom = false;

    private void Awake()
    {
        //sets our score to zero and writes in a blank value for the score indicator, then displays score.
        score = 0;
        displayscore = 0;
        //scoreUiIndicator.text = "";
        scoreUI.text = displayscore.ToString();
        //bonussystem.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //check to see the topmost score of our list of update scores
        //see if our score is equal to that score, if not update at display rate until we reach that score
        if (staticUpdater)
        {
            //check if our score is negative
            //if (scorelist >= 0)
            //{
                if (displayscore < score) //+ scorelist
                {
                    //get number of digits in our scorelist
                    //dignum = Math.Floor(Math.Log10(scorelist));
                //increment displayscore by displayrate*Time.Deltatime*10^dignum
                //displayscore += (int)(displayrate * Math.Pow(10, dignum) * Time.deltaTime);
                displayscore += (int)displayrate;
                    scoreUI.text = displayscore.ToString();
                    //if we meet that score, can remove topmost score off our list and check the next one on the next frame
                    if (displayscore >= score) //+ scorelist
                    {
                        //update our score
                        //score += scorelist;
                        //shift numscores to reflect the new end of array
                        displayscore = score;
                        scoreUI.text = displayscore.ToString();
                        //scoreUiIndicator.text = "";
                        staticUpdater = false;
                        if (comeInFromDecay || comeInFromRandom)
                        {
                            ScoreUpdater(basescore);
                            comeInFromDecay = false;
                            comeInFromRandom = false;
                        }
                    }
                }
            //} else
            //{
            //    if (displayscore > score + scorelist)
            //    {
            //        //get number of digits in our scorelist
            //        dignum = Math.Floor(Math.Log10(Math.Abs(scorelist)));
            //        //increment displayscore by displayrate*Time.Deltatime*10^dignum
            //        displayscore -= (int)(displayrate * Math.Pow(10, dignum) * Time.deltaTime);
            //        scoreUI.text = displayscore.ToString();
            //        //if we meet that score, can remove topmost score off our list and check the next one on the next frame
            //        if (displayscore <= score + scorelist)
            //        {
            //            //update our score
            //            score += scorelist;
            //            //shift numscores to reflect the new end of array
            //            displayscore = score;
            //            scoreUI.text = displayscore.ToString();
            //            scoreUiIndicator.text = "";
            //            staticUpdater = false;
            //        }
            //    }
            //}
        }
        //if our decay system is active, reduce internal decayscore by the decay rate, if we meet our condition to add the decayscore to our score, we stop decaying and run that score into the updater
        if (decayUpdater)
        {
            decayscore -= (int)(decayrate * Time.deltaTime);
            bonusUI.text = decayscore.ToString();
            //Debug.Log(decayscore.ToString());
            //if we meet our success condition for decayscore, we throw the current decayscore into scoreupdater, reset updater and return decayscore to zero
            if (decayCondition)
            {
                bonussystem.enabled = false;
                decayUpdater = false;
                decayCondition = false;
                ScoreUpdater(decayscore);
                comeInFromDecay = true;
                decayscore = 0;
            }
        }
        //Debug.Log(scorelist); 
    }

    public void ScoreUpdater(int scorein)
    {
        staticUpdater = true;
        //check to see if the uiindicator already has a score, if it does, add new line to uiindicator with next score(s) to add in
        scorelist = scorein;
        string sign;
        switch (Math.Sign(scorein)) {
            case 1:
                sign = "+";
                break;
            case -1:
                sign = "-";
                break;
            default:
                sign = "+";
                break;
        }
        // for loop here to go through all nonzero elements in scorelist
        string fulldisplay = sign + Math.Abs(scorein).ToString() + "\r\n";
        // display our scoreins on UI Indicator
        scoreUiIndicator.text = fulldisplay;
        //go to next element in our list when adding new scores
    }

    public static void ScoreUp(int scorein)
    {
        score += scorein;
        staticUpdater = true;
    }

    //public void graspTriggerInit()
    //{
    //    Transform objpos = gameObject.GetComponent<Transform>();
    //    // check to see if our object is outside its starting position
    //    if (Vector3.Distance(objpos.position, ResetPos.defaultpos) < .1)
    //    {
    //       // Debug.Log("Decay Start!");
    //        decayUpdater = true;
    //        decayscore = decaystart;
    //        bonussystem.enabled = true;
    //    } else
    //    {
    //       // Debug.Log("Decay Nope!");
    //        decayUpdater = false;
    //        decayscore = 0;
    //    }
    //    ScoreUpdater(basescore);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Transform objpos = gameObject.GetComponent<Transform>();
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.name == "PPCylinder")
    //    {
    //        //Debug.Log("Placed!");
    //        if (decayUpdater)
    //        {
    //            decayCondition = true;

    //        }
    //        else
    //        {
    //            comeInFromRandom = true;
    //        }
    //        return;
    //    }
    //    if (collision.gameObject.name == "PMCylinder")
    //    {
    //        //Debug.Log("Start Trigger!");
    //        return;
    //    }
    //    if (collision.gameObject.transform.parent.name == "Table" && Vector3.Distance(objpos.position, ResetPos.defaultpos) > .01)
    //    {
    //        //if we hit a collision that is not our desired condition or our hand, we reset our decay score and subtract points.
    //        bonussystem.enabled = false;
    //        decayUpdater = false;
    //        decayscore = 0;
    //        ScoreUpdater(-1 * basescore);
    //    }



    //}
}