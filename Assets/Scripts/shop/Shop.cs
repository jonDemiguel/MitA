using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private List<ShopItem> inventory = new List<ShopItem>();

    public void AddItemToShop(ShopItem item)
    {
        inventory.Add(item);
        Debug.Log("Added " + item.itemName + " to shop inventory.");
    }

    public void RemoveItemFromShop(ShopItem item)
    {
        if (inventory.Remove(item))
        {
            Debug.Log("Removed " + item.itemName + " from shop inventory.");
        }
        else
        {
            Debug.Log(item.itemName + " is not in the shop inventory.");
        }
    }

    public void BuyItem(ShopItem item, Wallet playerWallet)
    {
        if (inventory.Contains(item) && item.stock > 0 && playerWallet.GetBalance() >= item.price)
        {
            playerWallet.Withdraw(item.price);
            item.stock--;  // Decrement the item stock
            Debug.Log("Purchased " + item.itemName + ". Remaining balance: " + playerWallet.GetBalance());

            // Remove the item from inventory if sold out
            if (item.stock == 0)
            {
                RemoveItemFromShop(item);
            }
        }
        else if (!inventory.Contains(item) || item.stock == 0)
        {
            Debug.Log(item.itemName + " is not available for purchase.");
        }
        else
        {
            Debug.Log("Insufficient funds to purchase " + item.itemName + ".");
        }
    }
}