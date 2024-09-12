using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver, heart0, heart1, heart2, heart3, questions, timer, scorePanel;
    public static int health;
    public static int score;
    public static int stage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentHealth")){
            health = PlayerPrefs.GetInt("CurrentHealth");
        }else{
            health = 4;
        }

        if(PlayerPrefs.HasKey("CurrentScore")){
            score = PlayerPrefs.GetInt("CurrentScore");
        }else{
            score = 0;
        }
        
        if(PlayerPrefs.HasKey("CurrentStage")){
            stage = PlayerPrefs.GetInt("CurrentStage");
        }else{
            stage = 1;
            PlayerPrefs.SetInt("CurrentStage", stage);
        }

        timer.gameObject.SetActive(true);
        heart0.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        questions.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        scorePanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch(health){
            case 4:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 3:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 2:
                heart0.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            default:
                timer.gameObject.SetActive(false);
                heart0.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                questions.gameObject.SetActive(false);
                scorePanel.gameObject.SetActive(false);
                Time.timeScale = 0;
                break;

        }
    }

    public void Restart(){
        score = 0;
        health = 4;
        stage = 1;
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.DeleteKey("CurrentHealth");
        PlayerPrefs.DeleteKey("CurrentStage");
        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
