using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
          Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();
            playerController.PickupKey();
            Destroy(gameObject);
        }
    }
}
