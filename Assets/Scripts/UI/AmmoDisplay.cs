using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
        public GameObject player;
        public TextMeshProUGUI ammoDisplay;
        private Inventory inventoryScript;
        private GunMechanics currWeaponScript;
        private int bulletsLeft, totalBulletsLeft;
        void Start()
        {
                inventoryScript = player.GetComponent<Inventory>();
                Update();
        }

        void Update()
        {
                currWeaponScript = inventoryScript.equippedItem.GetComponent<GunMechanics>();
                if (currWeaponScript == null)
                {
                        ammoDisplay.text = "Fists";
                }
                else
                {
                        bulletsLeft = currWeaponScript.bulletsLeft;
                        totalBulletsLeft = currWeaponScript.totalBulletsLeft;
                        ammoDisplay.text = bulletsLeft.ToString() + "/" + totalBulletsLeft.ToString();
                }

        }
}
