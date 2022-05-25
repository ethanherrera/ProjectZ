using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
        public EnemyLogic enemyLogic;
        public int damage;
        public float attackCooldown;
        public float knockbackForce;
        public bool readyToAttack;
        private void Start()
        {
                readyToAttack = true;
                enemyLogic = GetComponent<EnemyLogic>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
                GameObject collisionGameObject = collision.gameObject;
                if (readyToAttack && collisionGameObject.name == "PlayerModel")
                        BasicAttack(collisionGameObject);
        }

        private void BasicAttack(GameObject receiver)
        {
                DamageCalc(receiver);
                Knockback(receiver);
                readyToAttack = false;
                enemyLogic.canMove = false;
                Invoke("ResetAttack", attackCooldown);
        }

        private void DamageCalc(GameObject receiver)
        {
                if (receiver.name == "PlayerModel" && GetComponent<Health>() != null)
                        receiver.GetComponent<Health>().TakeDamage(damage);
        }

        private void ResetAttack()
        {
                readyToAttack = true;
                enemyLogic.canMove = true;
        }

        private void Knockback(GameObject receiver)
        {
                Vector2 knockbackDir = (receiver.transform.position - transform.position).normalized;
                receiver.GetComponent<PlayerMovement>().Knockback(knockbackDir * knockbackForce);
        }
}
