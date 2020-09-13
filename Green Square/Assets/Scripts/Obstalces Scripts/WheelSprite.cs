using UnityEngine;

public class WheelSprite : MonoBehaviour
{

    void FixedUpdate()
    {
        if (gameObject.tag == "Wheel")
        {
         
            transform.Rotate(new Vector3(0, 0,Time.deltaTime*500));
            if (PauseMenuScript.GameIsPause == true)
                transform.Rotate(0, 0, 0);

        } else if (gameObject.tag == "WheelI")
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime*150));
            if (PauseMenuScript.GameIsPause == true)
                transform.Rotate(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControllers.health = 0;
        }
    }
}