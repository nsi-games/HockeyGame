using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIArea : MonoBehaviour
{
    public Collider ai_Collider;
    public Vector3 ai_Center;
    public Vector3 ai_Size, ai_Min, ai_Max;

    public bool puckInBounds;

    public GameObject puck;
    public GameObject AI;
    public float speed;
    public Transform startingPosition;


    // Use this for initialization
    void Start()
    {
        //Fetch the Collider from the GameObject
        ai_Collider = GetComponent<Collider>();
        //Fetch the center of the Collider volume
        ai_Center = ai_Collider.bounds.center;
        //Fetch the size of the Collider volume
        ai_Size = ai_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        ai_Min = ai_Collider.bounds.min;
        ai_Max = ai_Collider.bounds.max;
        //Output this data into the console
        OutputData();

        speed = 5;
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + ai_Center);
        Debug.Log("Collider Size : " + ai_Size);
        Debug.Log("Collider bound Minimum : " + ai_Min);
        Debug.Log("Collider bound Maximum : " + ai_Max);
    }

    void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Puck")
        {
            puckInBounds = true;
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.name == "Puck")
        {
            puckInBounds = false;

        }
    }
    void Update()
    {
        if(ai_Collider.bounds.Contains(puck.transform.position))
        {
            AI.GetComponent<Rigidbody>().AddForce(-puck.transform.position * speed);
        }
        else
        {
            AI.transform.position = Vector3.Lerp(AI.transform.position, startingPosition.transform.position, 5);
        }
    }
}
