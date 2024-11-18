using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelController : MonoBehaviour
{
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonNext;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonQuit.onClick.AddListener(MainMenu);
        buttonNext.onClick.AddListener(NextLevel);
    }

    public void LevelComplete()
    {
        this.gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        this.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

    }
}
