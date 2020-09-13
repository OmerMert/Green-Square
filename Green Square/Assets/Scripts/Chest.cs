using UnityEngine;

public class Chest : MonoBehaviour
{

    public Sprite openChest;
    public GameObject Coin;
    public Transform SpawnPosition;
    public Vector3 offSet;
    public ParticleSystem TreasureEffect;

    bool isOpen;
    public static bool isTaken;

    private void Start()
    {
        isOpen = false;
        isTaken = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (isOpen == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = openChest;
                TreasureEffect.Play();
                Invoke("SpawnCoin", 2f);
                isOpen = true;
                isTaken = true;
            }
        }
    }

    void SpawnCoin()
    {
        var location = SpawnPosition.position + offSet;
        for(int i = 0;i < 5;i++)
        {
            Instantiate(Coin, location, SpawnPosition.rotation);
            location.x += 0.5f;
        }
    }

}
