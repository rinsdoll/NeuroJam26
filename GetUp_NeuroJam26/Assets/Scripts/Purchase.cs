using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    [Header("Purchase")]
    public int saleIndex;
    [SerializeField] Button purchaseButton;
    [SerializeField] GameObject purchaseActive;
    [SerializeField] GameObject purchaseDisabled;

    /*private void Start()
    {
        purchaseDisabled.SetActive(true);
        purchaseActive.SetActive(false);
        purchaseButton.enabled = false;
    }*/


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
            case 2: //Unlock cat on lap
                HandlePurchase(2);
                ShopManager.instance.UpgradeIndex2();
                break;
            case 3: //Unlock TV
                HandlePurchase(3);
                ShopManager.instance.UpgradeIndex3();
                break;
            case 4: //Unlock Books
                HandlePurchase(4);
                ShopManager.instance.UpgradeIndex4();
                break;
            case 5: //Unlock Art
                HandlePurchase(5);
                ShopManager.instance.UpgradeIndex5();
                break;
            case 6: //Important
                HandlePurchase(6);
                ShopManager.instance.UpgradeIndex6();
                break;
            case 7: //Hungry
                HandlePurchase(7);
                ShopManager.instance.UpgradeIndex7();
                break;
            case 8: //Bathroon
                HandlePurchase(8);
                ShopManager.instance.UpgradeIndex8();
                break;
            case 9: //Sit Player Up, Progress won't go below 50%
                HandlePurchase(9);
                ShopManager.instance.UpgradeIndex9();
                break;
            case 10: //Spikes
                HandlePurchase(10);
                ShopManager.instance.UpgradeIndex10();
                break;
            case 11: //Sunny Day
                HandlePurchase(11);
                ShopManager.instance.UpgradeIndex11();
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

    public void TogglePurchaseActive(bool canPurchase)
    {
        if (canPurchase)
        {
            purchaseDisabled.SetActive(false);
            purchaseActive.SetActive(true);
            purchaseButton.enabled = true;
        }
        else
        {
            purchaseDisabled.SetActive(true);
            purchaseActive.SetActive(false);
            purchaseButton.enabled = false;
        }
    }

}
