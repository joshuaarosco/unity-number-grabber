using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public GameObject timerPanel;

    [SerializeField] Text countdownText;
    void Start()
    {
        string gameCategory = StaticData.gameCategory;
        // Add all questions to the list
        switch (gameCategory)
        {
            case "ip_address":
                currentTime = 5f;
                break;
            default:
                currentTime = startingTime;
                break;
        }
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerPanel.SetActive(false);

            // Spawn falling options
            SpawnOptions.StartSpawn();
            this.enabled  = false;
        }
    }
    public void TapToStart(){

    }
}