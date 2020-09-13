using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public SpriteRenderer  button;
    public Sprite PressedButton;

    public GameObject platform;

    public GameObject[] StairPlatforms;
    int a = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.sprite = PressedButton;
            Object.Destroy(platform);
            Stair();
        }
    }

    public void Stair()
    {
        StairPlatforms[a].SetActive(true);
        a++;
        if (a < StairPlatforms.Length)
            Invoke("Stair", 1);
    }

}