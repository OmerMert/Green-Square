using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllers : MonoBehaviour {

    public SpriteRenderer square;

    public static int health;

    private float speedX;
    private float jumpspeedY = 300;

    Vector3 scale;

    Rigidbody2D rb;

    public static bool jumping;

    public GameObject dead, NextLevelMenuUI;

    //HEARTS
    public Image[] hearts;

    //COLOURS
    public Sprite[] Colour;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 3;

        //PLAYER COLOUR
        for (int i = 1; i <= 6; i++)
        {
            if (CustomizationScript.Colour == i)
                square.sprite = Colour[i - 1];
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer(speedX);

        //HEARTS
        if (health < 3)
            Destroy(hearts[2]);
        if (health < 2)
            Destroy(hearts[1]);
        if (health < 1)
        { 
            Destroy(hearts[0]);
            CheckDeath();
        }
            

    }

    // PLAYER MOVEMENT  
    public void LeftB()
    {
        speedX = -3;
    }
    public void RigtB()
    {
        speedX = 3;
    }

    void MovePlayer(float Playerspeed)
    {
        rb.velocity = new Vector3(Playerspeed, rb.velocity.y, 0);
        Vector3 movement = new Vector3(1, 0f, 0f);
        transform.position += movement * Playerspeed * Time.fixedDeltaTime;
    }

    public void StopMoving()
    {
        speedX = 0;
    }
    
    //JUMPING
    public void JumpB()
    {
        if (jumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpspeedY));
            jumping = true;
            AudioScript.PlaySound("Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if ((collision.gameObject.tag == "Ground") || (collision.gameObject.tag == "MovingPlatform")
                                                    || (collision.gameObject.tag == "Rock")
                                                    || (collision.gameObject.tag == "Box"))
        {
            jumping = false;
        }

        //TAKE DAMAGE
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(hearts[0]);
            Destroy(hearts[1]);
            Destroy(hearts[2]);
            health = 0;
            CheckDeath();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerTakeDamage();
            KnockBack(collision);
        }
        

        //ATTACH TO MOVING PLATFORM
        if (collision.transform.tag == "MovingPlatform")
        {
            scale = this.transform.localScale;
            transform.parent = collision.transform;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
            this.transform.localScale = scale;
        }
    }

    void PlayerTakeDamage()
    {
        health--;
        AudioScript.PlaySound("Hit");
        CheckDeath();
    }
     public void KnockBack(Collision2D a)
    {
        Vector2 moveDirection;
        moveDirection.x = rb.transform.position.x - a.transform.position.x;
        moveDirection.y = 1;
        rb.AddForce(moveDirection.normalized * 3f,ForceMode2D.Impulse);
    }
    
    void CheckDeath()
    {
        if (health <= 0)
        {
            AudioScript.PlaySound("GameOver");
            gameObject.SetActive(false);
            Instantiate(dead, transform.position, transform.rotation);
            Invoke("restart", 0.5f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //LEVEL PASSING
        if (collision.gameObject.tag == "Flag")
        {
            Invoke("PassLevel", 0.3f);
            LevelsScript.levelPassed[SceneManager.GetActiveScene().buildIndex - 4] = true;
        }

    }
    void PassLevel()
    {
        NextLevelMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    


}










