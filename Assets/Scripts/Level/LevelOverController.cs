using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{

    [SerializeField] private GameObject LevelCompletedPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished");
            LevelManager.Instance.MarkCurrentLevelComplete();
            LevelCompletedPanel.SetActive(true);
        }
    }
}
