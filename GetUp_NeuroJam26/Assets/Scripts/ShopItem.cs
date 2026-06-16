using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    //TODO:ButtonIdex, itemCost, ToggleDescription()

    [Header ("Button Info")]
    public int buttonIndex;
    public int itemCost;
    public bool itemPurchased = false;

    [Header("Description Bubble")]
    [SerializeField] GameObject descriptionPanel;
    [SerializeField] Button purchaseButton;
    public bool descriptionActive = false;

    public void ToggleDescription()
    {
        if (descriptionActive)
        {
            //for ShopItems[i] -> Toggle any active descriptions
            descriptionPanel.SetActive (false);
            descriptionActive = false;
            SetActiveIndex(-1);
        }
        else
        {
            descriptionPanel.SetActive (true);
            descriptionActive = true;
            SetActiveIndex(buttonIndex);
            PurchaseEnabled();
        }
    }

    void SetActiveIndex(int index)
    {
        purchaseButton.GetComponent<Purchase>().saleIndex = index;
    }

    void PurchaseEnabled()
    {
        if (itemCost <= ButtonController.instance.coins &&  itemPurchased)
        {
            purchaseButton.enabled = true;
        }
        else
        {
            purchaseButton.enabled = false;
        }
    }
}
