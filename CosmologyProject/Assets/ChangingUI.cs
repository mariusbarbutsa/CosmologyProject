using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingUI : MonoBehaviour
{

    public Canvas mainMenu;
    public Canvas difficultyScene;
    public Canvas quizEasyScreen;
    public Canvas resultsScreen;
    public GameObject question1;



    public void PlayQuizButton()
    {
        mainMenu.gameObject.SetActive(false);
        difficultyScene.gameObject.SetActive(true);
    }

    public void GoBackDifficulty()
    {
        mainMenu.gameObject.SetActive(true);
        difficultyScene.gameObject.SetActive(false);
    }

    public void GoToEasyQuiz()
    {
        quizEasyScreen.gameObject.SetActive(true);
        difficultyScene.gameObject.SetActive(false);
        question1.gameObject.SetActive(true);
    }

    public void QuitQuiz()
    {
        quizEasyScreen.gameObject.SetActive(false);
        difficultyScene.gameObject.SetActive(true);
    }

}
