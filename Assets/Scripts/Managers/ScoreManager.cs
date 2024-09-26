using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    [SerializeField] Score scoreStat;


    [SerializeField] Text text;


    void Awake ()
    {
        score = 0;

        scoreStat.score = score;
    }


    void Update ()
    {
        text.text = "Score: " + scoreStat.score;
    }
}
