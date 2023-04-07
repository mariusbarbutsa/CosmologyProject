
using UnityEngine;
using TMPro;
using System.Reflection;
using UnityEngine.SceneManagement;



public class ChangingUI : MonoBehaviour
{

    public Canvas mainMenu;
    public Canvas difficultyScene;
    public Canvas quizEasyScreen;
    public Canvas resultsScreen;
    public GameObject question1;
    QuizManager timer = new QuizManager();
    public TextMeshProUGUI timeText;
    public GameObject mainMenuDisplay;
    public GameObject exploreDisplay;
    public GameObject displayedIntroText;
    public CanvasGroup backButton;
    public Transform transformList;




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
        Molecule transformOrigin = GameObject.Find("composites").GetComponentInChildren<Molecule>();
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

    public void GoToMainMenu()
    {
        mainMenuDisplay.gameObject.SetActive(true);
        exploreDisplay.gameObject.SetActive(false);
    }

    public void GoToExplore()
    {
        mainMenuDisplay.gameObject.SetActive(false);
        exploreDisplay.gameObject.SetActive(true);
    }

    public void DisplayIntroText()
    {
        displayedIntroText.SetActive(true);
        backButton.alpha = 1;
    }

    public void ResetExplore()
    {
        GameManager.Instance.ChangePlanet(PlanetTag.None);
        for (int i = 0; i < transformList.childCount; i++)
        {
            transformList.GetChild(i).gameObject.SetActive(true);
        }
    }

}
