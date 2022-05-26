using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
        public InventoryDisplay inventoryDisplay;
        public InventorySlot[] inventorySlots;
        public GameObject equippedItem;
        public ContainerSO availableWeapons;
        public int size;

        public class InventorySlot
        {
                public WeaponSO weapon;
                public Sprite weaponSprite;
                public GameObject weaponGameobject;

                public InventorySlot(WeaponSO weapon)
                {
                        this.weapon = weapon;
                        this.weaponSprite = weapon.sprite;
                        weaponGameobject = Instantiate(weapon.weaponPrefab, GameObject.Find("EquippedWeapon").transform.position, Quaternion.identity);
                        weaponGameobject.transform.SetParent(GameObject.Find("Inventory").transform);
                }
        }

        private void Start()
        {
                inventorySlots = new InventorySlot[size];
                AddWeaponToInventory((WeaponSO)availableWeapons.objects[1]);
                AddWeaponToInventory((WeaponSO)availableWeapons.objects[0]);
                equippedItem = inventorySlots[0].weaponGameobject;
        }

        private void Update()
        {
                MyInput();
        }

        private void MyInput()
        {
                for (int i = 0; i < size; i++)
                {
                        if (Input.GetKey("" + i))
                        {
                                equippedItem.transform.SetParent(GameObject.Find("Inventory").transform);
                                if (inventorySlots[i] != null)
                                {
                                        equippedItem = inventorySlots[i].weaponGameobject;
                                        SpriteRenderer spriteRend = equippedItem.GetComponent<SpriteRenderer>();
                                        spriteRend.enabled = true;
                                }
                                else
                                {
                                        equippedItem = inventorySlots[0].weaponGameobject;
                                        equippedItem.GetComponent<SpriteRenderer>().enabled = true;
                                }
                                equippedItem.transform.SetParent(GameObject.Find("EquippedWeapon").transform);
                        }
                        if (inventorySlots[i] != null && inventorySlots[i].weaponGameobject != equippedItem)
                        {
                                inventorySlots[i].weaponGameobject.GetComponent<SpriteRenderer>().enabled = false;
                        }
                }
        }

        public void AddWeaponToInventory(WeaponSO weapon)
        {
                for (int i = 0; i < inventorySlots.Length; i++)
                {
                        if (inventorySlots[i] == null)
                        {
                                inventorySlots[i] = new InventorySlot(weapon);
                                break;
                        }
                }
        }
}
