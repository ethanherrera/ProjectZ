using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
        public Rigidbody2D rigidBody;
        public float moveSpeed;

        public bool canMove;
        public Vector3 currDir;
        private Vector3 startPos;
        private Vector3 currPos;
        private GameObject target;

        private void Start()
        {
                startPos = this.transform.position;
                currPos = this.transform.position;
                target = SceneManager.Instance.player;
                canMove = true;
        }

        private void Update()
        {
                currPos = this.transform.position;
                currDir = (target.transform.position - transform.position).normalized;
        }

        private void FixedUpdate()
        {
                ChaseTarget(target);
        }

        private void ChaseTarget(GameObject target)
        {
                if (target)
                {
                        RotateModel();
                        MoveDirection(currDir);
                }
        }

        private void MoveDirection(Vector3 direction)
        {
                if (canMove)
                {
                        direction.Normalize();
                        rigidBody.MovePosition(currPos + direction
                            * moveSpeed * Time.fixedDeltaTime);
                }

        }

        private void RotateModel()
        {
                Vector3 targetPos = target.transform.position;
                targetPos.x -= transform.position.x;
                targetPos.y -= transform.position.y;
                targetPos.z = 0;
                transform.up = targetPos;
        }
}
