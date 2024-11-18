using System;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Button buttonPlay;
    public Button buttonExit;

    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonExit.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }

    public void QuitGame()

    {

        Application.Quit();

        Debug.Log("Quit");

    }
}
