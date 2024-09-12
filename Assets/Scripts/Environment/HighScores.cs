using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public string gameCategory;
    public TextMeshProUGUI textMeshProUGUI;    

    private int score;

    void Start(){
        if(!PlayerPrefs.HasKey("HighScoreArithmetic")){
            PlayerPrefs.SetInt("HighScoreArithmetic", 0);
        }
        if(!PlayerPrefs.HasKey("HighScoreRomanNumerals")){
            PlayerPrefs.SetInt("HighScoreRomanNumerals", 0);
        }
        if(!PlayerPrefs.HasKey("HighScoreNumberSystem")){
            PlayerPrefs.SetInt("HighScoreNumberSystem", 0);
        }
        if(!PlayerPrefs.HasKey("HighScoreASCII")){
            PlayerPrefs.SetInt("HighScoreASCII", 0);
        }
        if(!PlayerPrefs.HasKey("HighScoreIP")){
            PlayerPrefs.SetInt("HighScoreIP", 0);
        }
        PlayerPrefs.Save();
    }
    void Update(){
        if (textMeshProUGUI != null)
        {
            if(PlayerPrefs.HasKey("HighScoreArithmetic") && gameCategory == "arithmetic"){
                score = PlayerPrefs.GetInt("HighScoreArithmetic");
            }
            if(PlayerPrefs.HasKey("HighScoreRomanNumerals") && gameCategory == "roman_numerals"){
                score = PlayerPrefs.GetInt("HighScoreRomanNumerals");
            }
            if(PlayerPrefs.HasKey("HighScoreNumberSystem") && gameCategory == "number_system"){
                score = PlayerPrefs.GetInt("HighScoreNumberSystem");
            }
            if(PlayerPrefs.HasKey("HighScoreASCII") && gameCategory == "ascii"){
                score = PlayerPrefs.GetInt("HighScoreASCII");
            }
            if(PlayerPrefs.HasKey("HighScoreIP") && gameCategory == "ip_address"){
                score = PlayerPrefs.GetInt("HighScoreIP");
            }
            textMeshProUGUI.text = score.ToString();
        }
    }
}
