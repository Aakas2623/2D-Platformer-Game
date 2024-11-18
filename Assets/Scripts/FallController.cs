using UnityEngine;
using UnityEngine.SceneManagement;

public class FallController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Fall");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
