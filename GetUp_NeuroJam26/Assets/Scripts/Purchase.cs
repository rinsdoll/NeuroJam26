using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    [Header("Purchase")]
    public int saleIndex;
    [SerializeField] Button purchaseButton;

    public void PurchaseUpgrade()
    {
        switch (saleIndex)
        {
            case 0: //Unlock Progress Bar
                HandlePurchase(0);
                ShopManager.instance.UpgradeIndex0();
                break;
            case 1: //Uplock Spontanious Thought
                HandlePurchase(1);
                ShopManager.instance.UpgradeIndex1();
                break;
            case 9: //Sit Player Up, Progress won't go below 50%
                HandlePurchase(9);
                ShopManager.instance.UpgradeIndex9();
                break;
            default:
                break;
        }
    }

    void HandlePurchase(int index)
    {
        Debug.Log("Item " +  index + " Purchased");
        purchaseButton.enabled = false;
        ButtonController.instance.shopItems[index].GetComponent<ShopItem>().itemButton.enabled = false;
        ButtonController.instance.shopItems[index].GetComponent<ShopItem>().ToggleDescription();
        ButtonController.instance.SpendCoins(ButtonController.instance.shopItems[index].GetComponent<ShopItem>().itemCost);
    }

}
