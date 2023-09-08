using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private Transform camPos;

    [SerializeField] private float offset;
    void Update()
    {
        float rightRange = transform.position.x + offset;
        float leftRange = transform.position.x - offset;

        if (camPos.position.x >= rightRange) SetPosition(offset);

        if (camPos.position.x <= leftRange) SetPosition(-offset);
    }

    private void SetPosition(float distance)
    {
        transform.position = new Vector2(transform.position.x + distance, transform.position.y);
    }
}
