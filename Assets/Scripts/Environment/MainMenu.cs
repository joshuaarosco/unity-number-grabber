using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> menuBtnList;
    public List<GameObject> catBtnList;
    public List<GameObject> basicSubCatBtnList;
    public List<GameObject> intermediateSubCatBtnList;
    public GameObject homeBtnObject, highScorePanel, optionPanel, creditsPanel, aboutPanel;

    public float oldPosition = 107f;
    public float newPosition = -70f;

    void Start(){
        Time.timeScale = 1;
    }
    public void PlayGame(){

        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in catBtnList){
            if (obj != null){
                obj.SetActive(true);
            }
        }

        RectTransform rectTransform = homeBtnObject.GetComponent<RectTransform>();
        // Set this to the desired Y position
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, oldPosition);

        homeBtnObject.SetActive(true);
        PlayerPrefs.DeleteKey("CurrentHealth");
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.DeleteKey("CurrentStage");
        // SceneManager.LoadSceneAsync("Game");
    }

    public void Basic(){
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in catBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in basicSubCatBtnList){
            if (obj != null){
                obj.SetActive(true);
            }
        }

        
        RectTransform rectTransform = homeBtnObject.GetComponent<RectTransform>();
        // Set this to the desired Y position
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, oldPosition);

        homeBtnObject.SetActive(true);
    }

    
    public void Intermediate(){
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in catBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in intermediateSubCatBtnList){
            if (obj != null){
                obj.SetActive(true);
            }
        }

        
        RectTransform rectTransform = homeBtnObject.GetComponent<RectTransform>();
        // Set this to the desired Y position
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newPosition);

        homeBtnObject.SetActive(true);
    }


    public void Home(){
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(true);
            }
        }

        foreach (GameObject obj in catBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in basicSubCatBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in intermediateSubCatBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }

        highScorePanel.SetActive(false);
        optionPanel.SetActive(false);
        creditsPanel.SetActive(false);
        aboutPanel.SetActive(false);

        RectTransform rectTransform = homeBtnObject.GetComponent<RectTransform>();
        // Set this to the desired Y position
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, oldPosition);

        homeBtnObject.SetActive(false);
    }

    public void HighScore(){
        highScorePanel.SetActive(true);
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }
    }

    public void Option(){
        optionPanel.SetActive(true);
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }
    }

    public void Credits(){
        creditsPanel.SetActive(true);
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }
    }

    public void About(){
        aboutPanel.SetActive(true);
        foreach (GameObject obj in menuBtnList){
            if (obj != null){
                obj.SetActive(false);
            }
        }
    }

    public void ExitGame(){
        Application.Quit();
    }
}
