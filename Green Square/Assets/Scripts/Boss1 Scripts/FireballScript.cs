using UnityEngine;

public class FireballScript : MonoBehaviour {

    private int speedX,speedY;

    private void Start()
    {
        AudioScript.PlaySound("Fireball");

        if (gameObject.name == "FireballR(Clone)")
            speedX = 8;
        else if (gameObject.name == "FireballL(Clone)")
            speedX = -8;
        else
            speedX = 0;

        if (gameObject.name == "FireballD(Clone)")
            speedY = -8;
        else
            speedY = 0;

        Destroy(gameObject, 2);
    }

    void FixedUpdate () {
       Vector3 movement = new Vector3(1, 0, 0);
       transform.position += movement * speedX * Time.fixedDeltaTime;
        
        Vector3 movement1 = new Vector3(0, 1, 0);
        transform.position += movement1 * speedY * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "square")
        {
            Destroy(gameObject);
            PlayerControllers.health--;
            AudioScript.PlaySound("Hit");
        }      
    }



}
