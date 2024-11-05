using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Button buttonPlay;
    public Button buttonExit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonExit.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()

    {

        Application.Quit();

        Debug.Log("Quit");

    }
}
