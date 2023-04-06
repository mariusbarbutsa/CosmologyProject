using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangingUI : MonoBehaviour
{

    public Canvas mainMenu;
    public Canvas difficultyScene;
    public Canvas quizEasyScreen;
    public Canvas resultsScreen;
    public GameObject question1;
    QuizManager timer = new QuizManager();
    public TextMeshProUGUI timeText;
    




    public void PlayQuizButton()
    {
        mainMenu.gameObject.SetActive(false);
        difficultyScene.gameObject.SetActive(true);
        resultsScreen.gameObject.SetActive(false);
        question1.gameObject.SetActive(false);
        quizEasyScreen.gameObject.SetActive(false);
    }

    public void GoBackDifficulty()
    {
        mainMenu.gameObject.SetActive(true);
        difficultyScene.gameObject.SetActive(false);
        resultsScreen.gameObject.SetActive(false);
        question1.gameObject.SetActive(false);
        quizEasyScreen.gameObject.SetActive(false);
    }

    public void GoToEasyQuiz()
    {
        mainMenu.gameObject.SetActive(false);
        difficultyScene.gameObject.SetActive(false);
        resultsScreen.gameObject.SetActive(false);
        question1.gameObject.SetActive(true);
        quizEasyScreen.gameObject.SetActive(true);
        timer.StartCount();

    }

    public void QuitQuiz()
    {
        mainMenu.gameObject.SetActive(false);
        difficultyScene.gameObject.SetActive(true);
        resultsScreen.gameObject.SetActive(false);
        question1.gameObject.SetActive(false);
        quizEasyScreen.gameObject.SetActive(false);
    }

    public void ResultsScreen()
    {
        mainMenu.gameObject.SetActive(false);
        difficultyScene.gameObject.SetActive(false);
        resultsScreen.gameObject.SetActive(true);
        question1.gameObject.SetActive(false);
        quizEasyScreen.gameObject.SetActive(false);
        timer.StopCount();
    }

    public void SetTimeElapsed()
    {
        float elapsedTime = timer.GetElapsedTime();

        float minutes = Mathf.Floor(elapsedTime / 60f);
        float seconds = elapsedTime % 60; // The rest after removing the full amount as many times as you can

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

}
