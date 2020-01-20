/*********************************************************************
 * 
 * 
 * 
 * 
 * 
 * 
 *********************************************************************/

using UnityEngine;

public class ResetPos : MonoBehaviour
{
    [Header("Gameobject Referencing")]
    [Tooltip("The object that we are chainging the position of")]
    public GameObject Ouut;
    [Tooltip("The gameobject for the hand positioning we are referencing")]
    public GameObject handpos;

    [Header("Positional Refernecing")]
    [Tooltip("Bool that shows if we are disabled through collision, obsolete.")]
    public static bool _DIT = false;
    [Tooltip("The default position we want to transition to, is grabbed at Awake")]
    public static Vector3 defaultpos;

    //our gameobjects velocity
    Vector3 Vel;
    //our relative position to the handpos, we reference this for non-standard grabbing
    Vector3 relpos = new Vector3(0f, 0f, 0f);
    int points = 100;

    public static int complete = 0;

    private Rigidbody rb;
    private void Awake()
    {
        //Ouut.SetActive(false);
        //get our gameobjects rigidbody and get its default position. Store it for respawning
        rb = GetComponent<Rigidbody>();
        defaultpos = rb.position;
        transform.position = defaultpos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get our gameobjects rigidbody and check its position
        rb = GetComponent<Rigidbody>();
        Vel = rb.position;
        //if we get confirmation of grasp from glow
        //if (SerialComm.graspBool == '1')
        //{
        //    //get hand position and the relative distance from that to the cup, then use that to link cup to hand
        //    if (relpos - new Vector3(0f, 0f, 0f) == new Vector3(0f, 0f, 0f))
        //    {
        //        relpos = Vel - handpos.transform.position;
        //    }
        //    rb.position = relpos + handpos.transform.position;
        //} else
        //{
        //    relpos = new Vector3(0f, 0f, 0f);
        //}

        //Debug.Log(rb.position);
    }

    public void ResPos()
    {
        //transform our object to the default position and rotation, as well as cancel all velocity that would be inherited when respawning at original position
        transform.position = defaultpos;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //SerialComm.resetData();
        complete = 0;
    }

    public void Enab()
    {
        Ouut.SetActive(true);
        _DIT = false;
    }

    //private void OnTriggerEnter(Collider dataFromCollision)
    //{
    //    Debug.Log(dataFromCollision.gameObject.name);
    //    if (dataFromCollision.gameObject.name == "PPCylinder")
    //    {
    //        Debug.Log("Win");
    //        DelaySetGoThrough.trigDelay();
    //        //SerialComm.addVibrator(0xF0);
    //        //ScoreCounter.ScoreUp(points);
    //        Ouut.SetActive(false);
    //        _DIT = true;
    //        complete = 1;
    //    }

    //}
}
