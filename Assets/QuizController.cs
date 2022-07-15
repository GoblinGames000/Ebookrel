using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public enum Answer
{
    Yes,No
}
[System.Serializable]
public class Question
{
    [TextArea]
    public string QuestionText;
    public Answer _Answer;
}
public class QuizController : MonoBehaviour
{
    public List<Question> AllQuestions;
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI AnswerShow;

    private void OnEnable()
    {
        NextQuestion();
    }

    public void OnClickAnswer(bool Ans)
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        var ans = AllQuestions.Where(x => x.QuestionText == QuestionText.text).Select(x => x._Answer).FirstOrDefault();

        if ((ans == Answer.Yes && Ans)|| (ans==Answer.No && !Ans))
        {
            AnswerShow.gameObject.SetActive(true);
            AnswerShow.text = "Correct";
            AnswerShow.color=Color.blue;
        }
        else 
        {
            AnswerShow.gameObject.SetActive(true);
            AnswerShow.text = "Wrong";
            AnswerShow.color=Color.red;
            
        }
    }

    public int QuestionIndex;
    public void NextQuestion()
    {
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);

        QuestionIndex++;
        if (QuestionIndex >= AllQuestions.Count)
        {
            QuestionIndex = 0;
        }

        QuestionText.text = AllQuestions[QuestionIndex].QuestionText;

    }
    public void OnClickBack()
    {
        
        Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
        Fade.Instance.LoadScene("Main");
    }
}
