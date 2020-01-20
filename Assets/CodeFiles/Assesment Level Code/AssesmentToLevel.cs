using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssesmentToLevel : MonoBehaviour
{
    public static bool assignedtoalevel;
    // Start is called before the first frame update
    void Start()
    {
        assignedtoalevel = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void assignnewlevel()
    {
        if (StopWatchRedone.AssesmentTestComplete)
        { 
           if (StopWatchRedone.assesmentvalue >= 15)
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (StopWatchRedone.assesmentvalue >= 10 && StopWatchRedone.assesmentvalue < 15)
            {
                SceneManager.LoadScene("Level 2");
            }
           else if (StopWatchRedone.assesmentvalue >= 8 && StopWatchRedone.assesmentvalue < 10)
            {
               SceneManager.LoadScene("Level 3");
            }
            else if (StopWatchRedone.assesmentvalue >= 5 && StopWatchRedone.assesmentvalue < 8)
            {
               SceneManager.LoadScene("Level 4");
            }
            else if (StopWatchRedone.assesmentvalue >= 4 && StopWatchRedone.assesmentvalue < 5)
            {
                SceneManager.LoadScene("Level 5");
            }
            else if (StopWatchRedone.assesmentvalue >= 3 && StopWatchRedone.assesmentvalue < 4)
            {
                SceneManager.LoadScene("Level 6");
            }
            else if (StopWatchRedone.assesmentvalue < 3)
            {
                SceneManager.LoadScene("Level 7");
              
            }
            else { Debug.Log("How did I get here?"); }
        }
    }
}

