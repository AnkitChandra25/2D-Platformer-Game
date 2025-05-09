using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("Level Start !!!!");
        }
    }
}