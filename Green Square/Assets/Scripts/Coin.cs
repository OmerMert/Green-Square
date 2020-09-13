using UnityEngine;

public class Coin : MonoBehaviour {

    public ParticleSystem coinEffect;

    private void Start()
    {
        coinEffect.transform.position = transform.position;
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 100,0));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinEffect.Play();
            AudioScript.PlaySound("CoinPickUp");
            PointTextScript.coinAmount++;
            Destroy(gameObject);
        }
    }
}

