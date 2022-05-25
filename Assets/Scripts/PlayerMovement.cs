using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        public Camera cam;
        public Rigidbody2D rigidBody;
        public float moveSpeed;
        private bool canMove;
        private Vector2 currPosition;
        private Vector2 direction;
        private Vector2 mousePos;
        private void Start()
        {
                canMove = true;
        }
        private void Update()
        {
                MyInput();
        }
        private void FixedUpdate()
        {
                MovePlayer();
                RotatePlayer();
        }

        private void MyInput()
        {
                currPosition = rigidBody.position;
                direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        }
        private void MovePlayer()
        {
                if (canMove)
                {
                        direction.Normalize();
                        rigidBody.MovePosition(currPosition + direction
                            * moveSpeed * Time.fixedDeltaTime);
                }

        }

        private void RotatePlayer()
        {
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                mousePos.x -= transform.position.x;
                mousePos.y -= transform.position.y;
                transform.up = mousePos;
        }

        public void Knockback(Vector2 knockback)
        {
                rigidBody.velocity = knockback;
                canMove = false;
                Invoke("CanMove", .5f);
        }

        private void CanMove()
        {
                canMove = true;
        }
}

