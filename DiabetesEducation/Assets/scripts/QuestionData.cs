using System.Collections.Generic;

[System.Serializable]
public class QuestionData
{
    public string question;
    public List<string> reponses;
    public int reponseCorrecte;
}

[System.Serializable]
public class QuestionList
{
    public List<QuestionData> questions;
}
