[System.Serializable]
public class Question
{
    public string question;
    public string answer;
    public string[] options;
}

[System.Serializable]
public class QuestionList
{
    public Question[] questions, easy, medium, hard;
}