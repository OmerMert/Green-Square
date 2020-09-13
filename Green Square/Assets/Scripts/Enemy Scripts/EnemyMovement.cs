using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    bool movingRight;
    float speed = 1.3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveEnemy(speed);
       
    }

    void MoveEnemy(float Playerspeed)
    {
        rb.velocity = new Vector3(Playerspeed, rb.velocity.y, 0);
        Vector3 movement = new Vector3(1, 0f, 0f);
        transform.position += movement * Playerspeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turn")
        {
            if (movingRight)
            {
                speed = -speed;
                movingRight = false;
            }
            else
            {
                speed = -speed;
                movingRight = true;
            }
        }
    }



}
