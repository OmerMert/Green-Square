using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public GameObject Enemy;

    public ParticleSystem particle;

    Rigidbody2D playerRb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "square" && PlayerControllers.jumping == true)
        {
            particle.transform.position = Enemy.transform.position;
            AudioScript.PlaySound("Hit");
            particle.Play();
            Destroy(Enemy);
            KnockBackPlayer();

        }
    }

    void KnockBackPlayer()
    {
        playerRb = GameObject.Find("square").GetComponent<Rigidbody2D>();
        Vector2 velocity = playerRb.velocity;
        velocity.y = 1f;
        playerRb.velocity = velocity;

    }

}
