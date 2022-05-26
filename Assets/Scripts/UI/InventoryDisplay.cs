using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
        public Inventory playerInventory;
        public Image[] inventorySprites;

        private void Update()
        {
                for (int i = 1; i < playerInventory.size; i++)
                {
                        if (i < playerInventory.inventorySlots.Length)
                        {
                                if (playerInventory.inventorySlots[i] != null)
                                {
                                        inventorySprites[i - 1].enabled = true;
                                        inventorySprites[i - 1].sprite = playerInventory.inventorySlots[i].weaponSprite;
                                }
                                else
                                {
                                        inventorySprites[i - 1].enabled = false;
                                }
                        }
                }
        }
}
