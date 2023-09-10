using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Character character;
    private Vector3 targetPos;
    private Vector3[] points = new Vector3[2];
    private int pointIndex;
    void Start()
    {
        points[0] = transform.position + transform.right * 2f;
        points[1] = transform.position - transform.right * 2f;
        SetTargetPosition(0);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, targetPos);
        if (distance <= 0.5f)
        {
            pointIndex++;
            if (pointIndex > 1) pointIndex = 0;
            SetTargetPosition(pointIndex);
        }
        character.Move(targetPos.x - transform.position.x);
    }

    public void SetTargetPosition(int index)
    {
        targetPos = points[index];
    }
}
