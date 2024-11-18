using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonQuit;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonQuit.onClick.AddListener(MainMenu);   
    }

    public void PlayerDied()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        
        this.gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        this.gameObject.SetActive(false);
    }

}
