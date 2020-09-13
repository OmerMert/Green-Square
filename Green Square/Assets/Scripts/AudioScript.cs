using UnityEngine;

public class AudioScript : MonoBehaviour
{

    static AudioClip[] sound = new AudioClip[6];
    static AudioSource audioSrc;


    private void Start()
    {
        sound[0] = Resources.Load<AudioClip>("CoinPickUp");
        sound[1] = Resources.Load<AudioClip>("Jumping");
        sound[2] = Resources.Load<AudioClip>("Hit");
        sound[3] = Resources.Load<AudioClip>("GameOver");
        sound[4] = Resources.Load<AudioClip>("Fireball");
        sound[5] = Resources.Load<AudioClip>("HitGround");

        audioSrc = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    public static void PlaySound (string clip)
    {

     switch (clip){

            case "CoinPickUp":
                audioSrc.PlayOneShot(sound[0]);
                break;
            case "Jumping":
                audioSrc.PlayOneShot(sound[1]);
                break;
            case "Hit":
                audioSrc.PlayOneShot(sound[2]);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(sound[3]);
                break;
            case "Fireball":
                audioSrc.PlayOneShot(sound[4]);
                break;
            case "HitGround":
                audioSrc.PlayOneShot(sound[5]);
                break;
     }

    }

}
