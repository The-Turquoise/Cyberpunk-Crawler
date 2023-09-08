using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Transform[] points;
    private Vector3 targetPos;
    private int pointIndex;
    void Start()
    {
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
        targetPos = points[index].position;
    }
}
