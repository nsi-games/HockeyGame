using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Goal : MonoBehaviour
{
    public AudioClip scoreClip;
    private AudioSource audio;

    public int player;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        // play score sound
        audio.PlayOneShot(scoreClip);

        PuckControl puck = collider.gameObject.GetComponent<PuckControl>();
        puck.ResetPosition();

        Scorekeeper.Instance.OnScoreGoal(player);
    }
}
