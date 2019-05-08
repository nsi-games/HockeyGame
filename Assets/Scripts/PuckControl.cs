using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuckControl : MonoBehaviour
{
    public AudioClip wallCollideClip;
    public AudioClip paddleCollideClip;
    public LayerMask paddleLayer;

    private AudioSource audio;

    public Transform startingPos;
    private Rigidbody rigidbody;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        rigidbody = GetComponent<Rigidbody>();
        ResetPosition();
    }

    public void ResetPosition()
    {
        // teleport to the starting position
        rigidbody.MovePosition(startingPos.position);
        rigidbody.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name);
        if (paddleLayer.Contains(collision.gameObject))
        {
            // hit the paddle
            audio.PlayOneShot(paddleCollideClip);
        }
        else
        {
            // hit something else
            audio.PlayOneShot(wallCollideClip);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay: " + collision.gameObject.name);
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit: " + collision.gameObject.name);
    }
}
