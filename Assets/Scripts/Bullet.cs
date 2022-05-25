using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
        public int damage;
        private Vector3 initialPos;
        private void Awake()
        {
                initialPos = this.transform.position;
        }
        private void Update()
        {
                Vector3 currPos = this.transform.position;
                if (Vector3.Distance(initialPos, currPos) > 8)
                {
                        Destroy(gameObject);
                }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
                GameObject collisionGameObject = collision.gameObject;
                if (collisionGameObject.GetComponent<Health>() != null)
                        collisionGameObject.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
        }
}
