using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int keyCount = 0; // Current number of keys the player has
    public int potCount = 0;
    Inventory inventoryUI;
    HealingPotion hPot;

    private void Start()
    {
        inventoryUI = GetComponent<Inventory>();
        hPot = FindAnyObjectByType<HealingPotion>();
    }

    // Method to add a key to the player's inventory
    public void AddKey()
    {
        keyCount++;
        Debug.Log("Key added. Total keys: " + keyCount);
    }

    // Method to get the current key count
    public int GetKeyCount()
    {
        return keyCount;
    }

    // Method to check if the player has at least one key
    public bool HasKey()
    {
        return keyCount > 0;
    }

    // Method to use a key, reducing the key count by 1
    public void UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--;
            Debug.Log("Key used. Keys remaining: " + keyCount);
        }
        else
        {
            Debug.Log("No keys left to use.");
        }
    }

    public void AddPot()
    {
        potCount += hPot.potPickupAmount;
        Debug.Log("New Pot Added, Total Pots: " + potCount);
    }

    public void UsePotion()
    {
        if (potCount > 0)
        {
            potCount--;
            Debug.Log("pots used. pots remaing: " + potCount);
            if (potCount <= 0 && inventoryUI.invSlot.name == hPot.HealingPotionSprite.name) 
            {
                Debug.Log("fbiues");
            }
        }
        else
        {
            Debug.Log("no pots left to use");
        }
    }
}