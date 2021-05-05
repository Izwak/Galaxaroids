using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.score;
    }
}
