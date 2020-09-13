using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public SpriteRenderer boss;
    public Sprite bossSprite, bossVSprite;

    private int Bhealth;


    public Image[] hearts;
    public GameObject Button, Coins;
    public ParticleSystem DeadEffect;
    public ParticleSystem GroundHit;

    Animator anim;

    bool takenDamage;

    public CameraShake cameraShake;
    
    
    void Start()
    {
        Bhealth = 6;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (boss.sprite == bossSprite)
            takenDamage = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Player") && (boss.sprite == bossSprite))
        {
            PlayerControllers.health--;
            AudioScript.PlaySound("Hit");
            KnockBack();
        }
        else if ((collision.gameObject.tag == "Player") && (boss.sprite == bossVSprite))
        {
            if(takenDamage == false)
            {
                AudioScript.PlaySound("Hit");
                TakeDamage();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Hitting ground animation
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("JumpLAnim") || anim.GetCurrentAnimatorStateInfo(0).IsName("JumpRAnim")) 
                                                                                && collision.gameObject.name == "trigger")
        {
            StartCoroutine(cameraShake.Shake(.2f, .1f));
            AudioScript.PlaySound("HitGround");

            if (GroundHit.isPlaying)
                GroundHit.Stop();

            GroundHit.transform.position = new Vector2(transform.position.x,transform.position.y - 0.64f);
            GroundHit.Play();
            
        }
    }

    void TakeDamage()
    {
        Bhealth--;
        takenDamage = true;
        anim.SetTrigger("Vulnerable");
        Destroy(hearts[Bhealth]);
        AudioScript.PlaySound("Hit");
        CheckDead();
    }

    void KnockBack()
    {
        Rigidbody2D playerRb = GameObject.Find("square").GetComponent<Rigidbody2D>();
        Vector2 moveDirection;
        moveDirection.x = playerRb.transform.position.x - this.transform.position.x;
        moveDirection.y = 1;
        
        playerRb.AddForce(moveDirection.normalized * 3f, ForceMode2D.Impulse);
    }

    void CheckDead()
    {
        if (Bhealth <= 0)
        {
            DeadEffect.transform.position = this.transform.position;
            DeadEffect.Play();
            Destroy(gameObject);
            Button.SetActive(true);
            Coins.SetActive(true);
        }
    }

}