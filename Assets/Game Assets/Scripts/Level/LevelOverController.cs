using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            //Level is finished
            Debug.Log("Level Finished");
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }

}