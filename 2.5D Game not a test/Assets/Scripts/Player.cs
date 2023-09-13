using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform playerSprite;
    [SerializeField] private PlayerInteractions playerInteractions;
    private Vector2 move;
    private bool isWalking;
    private bool isFacingRight = true;

    void FixedUpdate()
    {
        HandleMovement();
    }

    public bool IsWalking() {
        return isWalking;
    }

    private void HandleMovement()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        isWalking = movement != Vector3.zero;

        //playerInteractions.HandleInteractions(movement);
    }

    public void OnMove(InputAction.CallbackContext contxt)
    {
        move = contxt.ReadValue<Vector2>();
        if((isFacingRight && move.x < 0) || (!isFacingRight && move.x > 0))
            Flip();
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = playerSprite.localScale;
        scale.x *= -1;
        playerSprite.localScale = scale;
    }
}
