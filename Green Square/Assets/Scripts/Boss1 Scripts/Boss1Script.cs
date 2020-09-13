using UnityEngine;
using UnityEngine.UI;

public class Boss1Script : MonoBehaviour {

    public SpriteRenderer boss1;
    public Sprite boss1LAttackSprite, boss1RAttackSprite, boss1V, boss1Sprite, boss1DAttackSprite;

    public static int Bhealth;

    public Image[] hearts;

    public ParticleSystem DeadEffect;

    public Transform firepoint;
    public GameObject Button, Coins, FireballR, FireballL, FireballD, Wings;

    Animator anim, wingLAnim, wingRAnim;
    bool stage2;

    bool takenDamage;

    void Start()
    {
        Bhealth = 6;
        stage2 = false;
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (boss1.sprite == boss1Sprite)
            takenDamage = false;


        //STAGE II
        if (Bhealth < 4)
        {
            anim.SetBool("Stage2", true);
            Wings.SetActive(true);
            stage2 = true;
        }

        //WINGS MOVEMENT
        if(boss1.sprite == boss1V && stage2 == true)
        {
            wingLAnim = GameObject.Find("WingL").GetComponent<Animator>();
            wingRAnim = GameObject.Find("WingR").GetComponent<Animator>();
            wingLAnim.SetBool("WingDown", true);
            wingRAnim.SetBool("WingDown", true);
        }
        else if(stage2  == true)
        {
            wingLAnim.SetBool("WingDown", false);
            wingRAnim.SetBool("WingDown", false);
            
        }


        //ATTACKING
        if (!GameObject.Find("FireballL(Clone)"))
        {
            if (boss1.sprite == boss1LAttackSprite)
            {
                Instantiate(FireballL, firepoint.position,firepoint.rotation);
            }
        }
        if (!GameObject.Find("FireballR(Clone)"))
        {
            if (boss1.sprite == boss1RAttackSprite)
            {
                Instantiate(FireballR, firepoint.position, firepoint.rotation);
            }
        }
        if (!GameObject.Find("FireballD(Clone)"))
        {
            if (boss1.sprite == boss1DAttackSprite)
            {
                Instantiate(FireballD, firepoint.position, firepoint.rotation);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Player") && ((boss1.sprite == boss1Sprite) || 
                         (boss1.sprite == boss1RAttackSprite) || (boss1.sprite == boss1LAttackSprite) || (boss1.sprite == boss1DAttackSprite)))
        {
            AudioScript.PlaySound("Hit");
            PlayerControllers.health --;
        }
        else if ((collision.gameObject.tag == "Player") && (boss1.sprite == boss1V))
        {
            if (takenDamage == false)
            {
                AudioScript.PlaySound("Hit");
                TakeDamage();
            }
            
        }
    }


    void TakeDamage()
    {
        Bhealth -= 1;
        takenDamage = true;
        anim.SetTrigger("Vulnerable");
        Destroy(hearts[Bhealth]);
        CheckDead();
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
