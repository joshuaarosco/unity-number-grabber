using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private GameAudioManager audioManager;
    [SerializeField] private string jsonFileName;
    [SerializeField] private Text uiText; // Reference to your Text UI component

    [SerializeField] GameObject[] optionsObj;
    [SerializeField] GameObject options;

    private QuestionList questionList;
    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex = -1;
    [SerializeField] AudioSource sfxSource;
    public AudioClip deadSFX, correctSFX;
    public float resetSeconds = 0.5f;

    void Start()
    {
        LoadQuestions();
        ShuffleQuestions();
        ShowNextQuestion();
    }

    void LoadQuestions()
    {
        string gameCategory = StaticData.gameCategory;
        // Add all questions to the list
        switch (gameCategory)
        {
            case "arithmetic":
                Debug.Log("Category is Arithmetic.");
                jsonFileName = "arithmetic2";
                break;
            case "roman_numerals":
                Debug.Log("Category is Roman Numeral.");
                jsonFileName = "roman_numerals";
                break;
            case "number_system":
                Debug.Log("Category is Number System.");
                jsonFileName = "number_system2";
                break;
            case "ascii":
                Debug.Log("Category is ASCII.");
                jsonFileName = "ascii";
                break;
            case "ip_address":
                Debug.Log("Category is IP Address.");
                jsonFileName = "ip_address";
                break;
            default:
                Debug.Log("Unknown difficulty.");
                break;
        }
        
        // Load the JSON file from Resources folder
        TextAsset jsonData = Resources.Load<TextAsset>(jsonFileName);
        
        if (jsonData != null)
        {
            // Deserialize the JSON data into the questionList object
            questionList = JsonUtility.FromJson<QuestionList>(jsonData.text);
            // questions.AddRange(questionList.questions);
            
            int currentStage = GameManager.stage;

            if(gameCategory == "roman_numerals" || gameCategory == "ip_address" || gameCategory == "ascii"){
                questions.AddRange(questionList.questions);
            }else{

                if(currentStage <= 15){
                    questions.AddRange(questionList.easy);
                }else if(currentStage > 15 && currentStage < 31){
                    questions.AddRange(questionList.medium);
                }else{
                    questions.AddRange(questionList.hard);
                }
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }
    }

    void ShuffleQuestions()
    {
        // Shuffle the list of questions
        for (int i = 0; i < questions.Count; i++)
        {
            Question temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }

    public void ShowNextQuestion()
    {
        if (questions.Count == 0)
        {
            uiText.text = "No more questions!";
            return;
        }

        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Count)
        {
            uiText.text = "No more questions!";
            return;
        }

        Question currentQuestion = questions[currentQuestionIndex];
        uiText.text = currentQuestion.question;

        // Shuffle the options for this question
        string[] shuffledOptions = ShuffleOptions(currentQuestion.options);

        // Display the shuffled options in the UI
        for (int i = 0; i < optionsObj.Length; i++)
        {
            if (i < shuffledOptions.Length)
            {
                TextMeshPro optionText = optionsObj[i].GetComponent<TextMeshPro>();
                if (optionText != null)
                {
                    optionText.text = shuffledOptions[i];
                }
                optionsObj[i].SetActive(true); // Make sure the option is active
            }
            else
            {
                optionsObj[i].SetActive(false); // Hide unused options
            }
        }
    }

    // Function to shuffle the options
    private string[] ShuffleOptions(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            int randomIndex = Random.Range(i, options.Length);
            string temp = options[i];
            options[i] = options[randomIndex];
            options[randomIndex] = temp;
        }
        return options;
    }

    public void OnPlayerAnswer(string playerAnswer)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        if (playerAnswer == currentQuestion.answer)
        {
            //Debug.Log("Correct!");
            
            GameManager.stage += 1;
            PlayerPrefs.SetInt("CurrentStage", GameManager.stage);

            GameManager.score += 1;
            PlayerPrefs.SetInt("CurrentScore", GameManager.score);

            UpdateHighScore(StaticData.gameCategory);
            
            sfxSource.clip = correctSFX;
            sfxSource.Play();

            StartCoroutine(ResetScene());
            // ShowNextQuestion();
        }
        else
        {
            //Debug.Log("Wrong answer. Try again.");
            
            GameManager.stage += 1;
            PlayerPrefs.SetInt("CurrentStage", GameManager.stage);

            GameManager.health -= 1;
            PlayerPrefs.SetInt("CurrentHealth", GameManager.health);
            
            sfxSource.clip = deadSFX;
            sfxSource.Play();
            
            if(GameManager.health > 1){
                StartCoroutine(ResetScene());
            }else{
                if (audioManager != null)
                {
                    audioManager.StopMusic();  // Stop the music here
                }
            }
            // Optionally, you can handle wrong answers here
        }
    }

    private IEnumerator ResetScene(){
        options.SetActive(false);
        yield return new WaitForSeconds(resetSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateHighScore(string gameCategory){
        int currentScore = PlayerPrefs.GetInt("CurrentScore", GameManager.score);
        if(PlayerPrefs.HasKey("HighScoreArithmetic") && gameCategory == "arithmetic"){
            if(currentScore > PlayerPrefs.GetInt("HighScoreArithmetic")){
                Debug.Log("High Score has been saved...");
                PlayerPrefs.SetInt("HighScoreArithmetic", currentScore);
                PlayerPrefs.Save();
            }
        }
        if(PlayerPrefs.HasKey("HighScoreRomanNumerals") && gameCategory == "roman_numerals"){
            if(currentScore > PlayerPrefs.GetInt("HighScoreRomanNumerals")){
                PlayerPrefs.SetInt("HighScoreRomanNumerals", currentScore);
                PlayerPrefs.Save();
            }
        }
        if(PlayerPrefs.HasKey("HighScoreNumberSystem") && gameCategory == "number_system"){
            if(currentScore > PlayerPrefs.GetInt("HighScoreNumberSystem")){
                PlayerPrefs.SetInt("HighScoreNumberSystem", currentScore);
                PlayerPrefs.Save();
            }
        }
        if(PlayerPrefs.HasKey("HighScoreASCII") && gameCategory == "ascii"){
            if(currentScore > PlayerPrefs.GetInt("HighScoreASCII")){
                PlayerPrefs.SetInt("HighScoreASCII", currentScore);
                PlayerPrefs.Save();
            }
        }
        if(PlayerPrefs.HasKey("HighScoreIP") && gameCategory == "ip_address"){
            if(currentScore > PlayerPrefs.GetInt("HighScoreIP")){
                PlayerPrefs.SetInt("HighScoreIP", currentScore);
                PlayerPrefs.Save();
            }
        }
    }
}
