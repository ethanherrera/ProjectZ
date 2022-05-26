using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
        public List<InventorySlots> inventory;

        public class InventorySlots
        {
                public WeaponSO weapon;
                public Sprite weaponSprite;

                InventorySlots(WeaponSO weapon)
                {
                        this.weapon = weapon;
                        this.weaponSprite = weapon.sprite;
                }
        }
}
