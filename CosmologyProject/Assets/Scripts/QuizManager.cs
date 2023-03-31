using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public Question[] questions;

    public void Update()
    {
        //add method: press on button to ask first question
        //Question myQuestion = GetQuestion(0);
    }

    public Question GetQuestion(int index)
    {
        index = Mathf.Clamp(index, 0, questions.Length - 1);
        return questions[index];
    }

    public bool ValidateQuestionAnswer(int index, string questionAnswer)
    {
        Question question = questions[index];
        if (question.answer == questionAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
