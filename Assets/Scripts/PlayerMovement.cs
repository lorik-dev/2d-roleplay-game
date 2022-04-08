using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;

    public float moveSpeed = 0.5f;

    public BoxCollider2D boxPlayer;

    RaycastHit2D boxHit;
    private void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementInput != Vector2.zero){
            boxHit = Physics2D.BoxCast(transform.position, boxPlayer.size, 0, new Vector2(0, movementInput.y), Mathf.Abs(movementInput.y * moveSpeed * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

            if (boxHit.collider == null)
            {
                transform.Translate(0, movementInput.y * moveSpeed * Time.deltaTime, 0);
            }

            boxHit = Physics2D.BoxCast(transform.position, boxPlayer.size, 0, new Vector2(movementInput.x, 0), Mathf.Abs(movementInput.x * moveSpeed * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

            //player movement
            if (boxHit.collider == null)
            {
                transform.Translate(movementInput.x * moveSpeed * Time.deltaTime, 0, 0);
            }

        }
    }
}