using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
        public int initialHealth;
        public int currHealth;
        private bool vulnerable;
        void Start()
        {
                currHealth = initialHealth;
                vulnerable = true;
        }

        public void TakeDamage(int damage)
        {
                if (vulnerable)
                {
                        if (currHealth - damage <= 0)
                        {
                                currHealth = 0;
                                Die();
                        }
                        else
                        {
                                currHealth -= damage;
                                Invulnerable(2);
                        }
                }



        }
        private void Invulnerable(float time)
        {
                vulnerable = false;
                Invoke("Vulnerable", time);
        }

        private void Vulnerable()
        {
                vulnerable = true;
        }
        private void Die()
        {
                Destroy(gameObject);
        }
}
