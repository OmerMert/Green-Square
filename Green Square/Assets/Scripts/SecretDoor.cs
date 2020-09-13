using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            this.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            this.gameObject.SetActive(true);
    }


}
