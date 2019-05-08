using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MovePaddle : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float speed = 20f;
    public float force = 10f;

    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
	}

    private Vector3 GetMousePosition()
    {
        // create a ray from the camera
        // passing through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // find out where the ray intersects the XZ plane
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance = 0;
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    void OnDrawGizmos()
    {
        // draw the mouse ray
        Gizmos.color = Color.yellow;
        Vector3 pos = GetMousePosition();
        Gizmos.DrawLine(Camera.main.transform.position, pos);
    }


    void Update()
    {
        Debug.Log("Time = " +Time.time);
    }
    void FixedUpdate()
    {
        Vector3 pos = GetMousePosition();
        Vector3 dir = pos - rigidbody.position;
        rigidbody.AddForce(dir.normalized * force);

        //Vector3 pos = GetMousePosition();
        //Vector3 dir = pos - rigidbody.position;
        //Vector3 vel = dir.normalized * speed;
        //// check is this speed is going to overshoot the target
        //float move = speed * Time.fixedDeltaTime;
        //float distToTarget = dir.magnitude;
        //if (move > distToTarget)
        //{
        //    // scale the velocity down appropriately
        //    vel = vel * distToTarget / move;
        //}
        //rigidbody.velocity = vel;
    }
}
