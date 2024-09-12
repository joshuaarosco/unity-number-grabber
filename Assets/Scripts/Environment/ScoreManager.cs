using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentScore")){
            scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString("0");
            finalScoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString("0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
