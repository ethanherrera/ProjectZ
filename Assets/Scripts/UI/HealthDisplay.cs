using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
        public Health playerHealth;
        public Slider healthSlider;
        public Slider shieldSlider;
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI shieldText;

        private void Start()
        {
                healthSlider.maxValue = playerHealth.maxHealth;
                healthSlider.value = playerHealth.maxHealth;
                shieldSlider.maxValue = playerHealth.maxShield;
                shieldSlider.value = playerHealth.maxShield;
        }

        private void Update()
        {
                SetHealthBars();
                SetHealthTexts();
        }

        private void SetHealthBars()
        {
                healthSlider.maxValue = playerHealth.maxHealth;
                healthSlider.value = playerHealth.currHealth;
                shieldSlider.maxValue = playerHealth.maxShield;
                shieldSlider.value = playerHealth.currShield;
        }

        private void SetHealthTexts()
        {
                healthText.text = playerHealth.currHealth.ToString() + "/" + playerHealth.maxHealth.ToString();
                shieldText.text = playerHealth.currShield.ToString() + "/" + playerHealth.maxShield.ToString();
        }
}
