using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{
    static private Scorekeeper instance;

    static public Scorekeeper Instance
    {
        get { return instance; }
    }

    void Start()
    {
        if (instance == null)
        {
            // save this instance
            instance = this;
        }
        else
        {
            // more than one instance exists
            Debug.LogError(
            "More than one Scorekeeper exists in the scene.");
        }

        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 0;
            scoreText[i].text = "0";

        }
    }

    public int pointsPerGoal = 1;
    private int[] score = new int[2];
    public Text[] scoreText;
    public int tempPoints;

    public void OnScoreGoal(int player)
    {
        score[player] += pointsPerGoal;
        scoreText[player].text = score[player].ToString();
    }
}