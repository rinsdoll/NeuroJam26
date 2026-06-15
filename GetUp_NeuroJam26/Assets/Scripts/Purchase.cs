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
                //HandlePurchase
                //Set progress bar visibility to active
                break;
            default:
                break;
        }
    }

    void HandlePurchase(int index)
    {
        Debug.Log("Item " +  index + " Purchased");
        purchaseButton.enabled = false;
        ButtonController.instance.shopItems[index].enabled = false;
        ButtonController.instance.shopItems[index].GetComponent<ShopItem>().ToggleDescription();
        ButtonController.instance.SpendCoins(ButtonController.instance.shopItems[index].GetComponent<ShopItem>().itemCost);
    }

}
