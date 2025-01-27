using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public Sprite HealingPotionSprite ; // Amount of health the potion restores
    public int potPickupAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory playerInvUi = other.GetComponent<Inventory>();
        PlayerInventory playerInv = other.GetComponent<PlayerInventory>();

        if(playerInvUi != null) 
        {
            playerInvUi.AddItem(HealingPotionSprite);
            playerInv.AddPot();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("PLayer Inv UI not found");
        }

    }
}

