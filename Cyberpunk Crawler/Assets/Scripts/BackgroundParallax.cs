using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] float parallaxEffect;
    [SerializeField] private float startPos, length;
    [SerializeField] private float temp, distance;
    private void Awake()
    {
        startPos = transform.position.x;
        length = GetComponent<MeshRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        temp = cam.transform.position.x * (1 + parallaxEffect);
        distance = cam.transform.position.x * -parallaxEffect;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
