using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished");
        }
    }
}
