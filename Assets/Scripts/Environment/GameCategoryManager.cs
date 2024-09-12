using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCategoryManager : MonoBehaviour
{
    public void Arithmetic(){
        StaticData.gameCategory = "arithmetic";
        SceneManager.LoadScene("Game");
    }
    public void RomanNumerals(){
        StaticData.gameCategory = "roman_numerals";
        SceneManager.LoadScene("Game");
    }
    public void NumberSystem(){
        StaticData.gameCategory = "number_system";
        SceneManager.LoadScene("Game");
    }
    public void ASCII(){
        StaticData.gameCategory = "ascii";
        SceneManager.LoadScene("Game");
    }
    public void IPAddress(){
        StaticData.gameCategory = "ip_address";
        SceneManager.LoadScene("Game");
    }
}
