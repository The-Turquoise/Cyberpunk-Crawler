using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Character character;

    private float horizontalInput;
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        character.Move(horizontalInput);

        if (Input.GetKeyDown(KeyCode.W))
        {
            character.Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Attack();
        }
    }
}