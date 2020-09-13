using UnityEngine;

public class JumpingPad : MonoBehaviour
{
    public int speed;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>
                          ().AddForce(Vector3.up * speed);
        }
    }
}
