using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public Sprite HealingPotionSprite ; // Amount of health the potion restores

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventoryUI = other.GetComponentInChildren<Inventory>();

            if (playerInventoryUI != null)
            {
                // Add the key sprite to the currently selected inventory slot
                playerInventoryUI.AddItem(HealingPotionSprite);
                Debug.Log("Potion Added.");

                // Destroy the key game object after collection
                Destroy(gameObject);
                Debug.Log("The Potion is Added in the Collection.");
            }
            else
            {
                Debug.Log("Player's inventory UI not found.");
            }
        }
    }
}

