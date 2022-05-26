using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
        public int maxHealth;
        public int currHealth;

        public int maxShield;
        public int currShield;
        private bool vulnerable;
        public float invulnerabilityTime;
        void Start()
        {
                currHealth = maxHealth;
                currShield = maxShield;
                vulnerable = true;
        }

        public void TakeDamage(int damage)
        {
                if (vulnerable)
                {
                        if (currShield > 0)
                        {
                                DamageCalcShield(damage);
                        }
                        else
                        {
                                DamageCalcHealth(damage);
                        }
                }
        }

        private void DamageCalcHealth(int damage)
        {
                if (currHealth - damage <= 0)
                {
                        currHealth = 0;
                        Die();
                }
                else
                {
                        currHealth -= damage;
                        Invulnerable();
                }
        }

        private void DamageCalcShield(int damage)
        {
                if (currShield - damage <= 0)
                {
                        int damageToHealth = damage - currShield;
                        currShield = 0;
                        DamageCalcHealth(damageToHealth);
                }
                else
                {
                        currShield -= damage;
                        Invulnerable();
                }
        }
        private void Invulnerable()
        {
                vulnerable = false;
                Invoke("Vulnerable", invulnerabilityTime);
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
