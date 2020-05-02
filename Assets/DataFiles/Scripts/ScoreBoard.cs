using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int ScorePerHit = 12;
    int score = 0;
    Text ScoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        ScoreText.text = score.ToString();
    }

    public void ScoreHit(int scoreBonus = 0)
    {
        score += ScorePerHit + scoreBonus;
        ScoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }
}
