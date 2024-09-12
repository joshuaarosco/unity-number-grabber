using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text stageText;
    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentStage")){
            Debug.Log("Hello you are @ StageManager Line 13");
            stageText.text = PlayerPrefs.GetInt("CurrentStage").ToString("0");
        }else{
            
            Debug.Log("Hello you are @ StageManager Line 17");
        }
    }
}
