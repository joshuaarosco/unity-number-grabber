using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public GameObject timerPanel, tapToStartPanel;

    [SerializeField] Text countdownText;
    // [SerializeField] Button startButton; // Reference to the start button
    private bool isTimerRunning = false; // To track if the timer has started
    void Start()
    {
        string gameCategory = StaticData.gameCategory;
        // Add all questions to the list
        switch (gameCategory)
        {
            case "ip_address":
                // currentTime = 5f;
                currentTime = startingTime;
                // Disable timer panel and show start button at the beginning
                timerPanel.SetActive(false);
                tapToStartPanel.SetActive(true);
                break;
            default:
                currentTime = startingTime;
                
                isTimerRunning = true;
                timerPanel.SetActive(true); // Show the timer UI when the countdown begins
                tapToStartPanel.SetActive(false); // Hide the start button once tapped
                break;
        }

    }
    void Update()
    {
        // Only run the timer if it has started
        if (isTimerRunning)
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
    }
    public void TapToStart(){
        isTimerRunning = true;
        timerPanel.SetActive(true); // Show the timer UI when the countdown begins
        tapToStartPanel.SetActive(false); // Hide the start button once tapped
    }
}