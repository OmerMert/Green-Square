using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    float scrollSpeed = 50f;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed , 1280);
        transform.position = startPos + Vector2.right * newPos;
    }
}
