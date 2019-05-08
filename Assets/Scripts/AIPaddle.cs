using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIPaddle : MonoBehaviour
{
    public Transform puck;
    public Transform goal;
    public float hitAmount = 2f;
    public float hitThreshold = 2f;
    public float dangerDistance = 5f;

    private NavMeshAgent agent;
    private Vector3 startingPoint;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(puck.position, goal.position);
        if(distance < dangerDistance)
        {
            Vector3 mid = (puck.position + goal.position) / 2f;
            agent.SetDestination(mid);

            float midDistance = Vector3.Distance(transform.position, mid);
            if (midDistance < hitThreshold)
            {
                agent.SetDestination(puck.position);
            }
        }
        else
        {
            agent.SetDestination(startingPoint);
        }
    }

    //private void OnCollisionEnter(Collision col)
    //{
    //    if(col.collider.tag == "Puck")
    //    {
    //        ContactPoint contact = col.contacts[0];
    //        Rigidbody rigid = col.collider.GetComponent<Rigidbody>();
    //        rigid.AddForce(contact.normal * hitAmount, ForceMode.Impulse);
    //    }
    //}
}
