using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    Collider pl_Collider;
    Vector3 pl_Center;
    Vector3 pl_Size, pl_Min, pl_Max;

    // Use this for initialization
    void Start()
    {
        //Fetch the Collider from the GameObject
        pl_Collider = GetComponent<Collider>();
        //Fetch the center of the Collider volume
        pl_Center = pl_Collider.bounds.center;
        //Fetch the size of the Collider volume
        pl_Size = pl_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        pl_Min = pl_Collider.bounds.min;
        pl_Max = pl_Collider.bounds.max;
        //Output this data into the console
        OutputData();
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + pl_Center);
        Debug.Log("Collider Size : " + pl_Size);
        Debug.Log("Collider bound Minimum : " + pl_Min);
        Debug.Log("Collider bound Maximum : " + pl_Max);
    }
}