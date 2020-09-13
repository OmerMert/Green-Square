using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    public ParticleSystem particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particle, collision.transform.position, Quaternion.identity);
    }
}
