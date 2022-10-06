using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject replayPanel;

    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void IsShowReplayPanel(bool isShow)
    {
        if (replayPanel)
        {
            replayPanel.SetActive(isShow);
        }
    }
}
