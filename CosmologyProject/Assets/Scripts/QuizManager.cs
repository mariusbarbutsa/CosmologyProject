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


    public void Update()
    {
        //add method: press on button to ask first question
        //Question myQuestion = GetQuestion(0);
    }

    public void Confirm()
    {
        Debug.Log(CheckSolution());
    }

    public bool CheckSolution()
    {
        int counter = 0;
        foreach (QuizTarget target in quizTargets)
        {
            if (target.assignedMolecule != MoleculeType.None)
            {
                // Debug.Log("A");
                if (correctAnswers.Contains(target.assignedMolecule))
                {
                    // Debug.Log("B");
                    counter++;
                }
                else
                {
                    // Debug.Log("C");
                    return false;
                }
            }
        }
        if (counter == 4)
        {
            scoreText.text = "1/1";
        }
        else
        {
            scoreText.text = "0/1";
        }

        return counter == correctAnswers.Count;
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

