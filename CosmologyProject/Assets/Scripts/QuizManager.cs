using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<MoleculeType> correctAnswers = new List<MoleculeType>();

    public QuizTarget[] quizTargets;


    public Question[] questions;
    public TextMeshProUGUI scoreText;
    private float startTime;
    private float endTime;
    private bool isCounting = false;
    private float elapsedTime = 0.0f;
    private int counter = 0;



    public void Update()
    {
        //add method: press on button to ask first question
        //Question myQuestion = GetQuestion(0);
    }

    public bool CheckSolution()
    {
        counter = 0; // reset the counter to zero at the beginning of the method

        foreach (QuizTarget target in quizTargets)
        {
            if (target.assignedMolecule != MoleculeType.None)
            {
                if (correctAnswers.Contains(target.assignedMolecule))
                {
                    counter++;
                }
                else
                {
                    return false;
                }
            }
        }

        return counter == correctAnswers.Count;
    }

    public void Confirm()
    {
        Debug.Log(CheckSolution());
        ResetCorrectQuestion();
        counter = 0;

    }

    public void ResetCorrectQuestion()
    {
        if (CheckSolution())
        {
            scoreText.text = "1/1";
        }
        else
        {
            scoreText.text = "0/1";

        }
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

    public void StartCount()
    {
        if (!isCounting)
        {
            startTime = Time.time;
            isCounting = true;
        }
    }

    public void StopCount()
    {
        if (isCounting)
        {
            endTime = Time.time;
            elapsedTime = endTime - startTime;
            isCounting = false;
        }
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}

