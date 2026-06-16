using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    //TODO:ButtonIdex, itemCost, ToggleDescription()

    [Header ("Button Info")]
    public int buttonIndex;
    public int itemCost;
    [SerializeField] TextMeshProUGUI costText;
    public bool itemPurchased = false;
    public Button itemButton;

    [Header("Description Bubble")]
    [SerializeField] GameObject descriptionPanel;
    public Button purchaseButton;
    public bool descriptionActive = false;

    private void Start()
    {
        costText.text = itemCost.ToString();
    }

    public void ToggleDescription()
    {
        if (descriptionActive)
        {
            //for ShopItems[i] -> Toggle any active descriptions
            descriptionPanel.SetActive (false);
            descriptionActive = false;
        }
        else
        {
            ButtonController.instance.ToggleAllButtonsDescription();
            descriptionPanel.SetActive (true);
            descriptionActive = true;
            PurchaseEnabled();
        }
    }

    public void SetActiveIndex()
    {
        if (!descriptionActive)
        {
            Debug.Log(buttonIndex.ToString());
            purchaseButton.GetComponent<Purchase>().saleIndex = buttonIndex;
        }
        else
        {
            purchaseButton.GetComponent<Purchase>().saleIndex = -1;
            Debug.Log(purchaseButton.GetComponent<Purchase>().saleIndex.ToString());
        }
    }

    void PurchaseEnabled()
    {
        if (itemCost <= ButtonController.instance.coins &&  !itemPurchased)
        {
            purchaseButton.enabled = true;
        }
        else
        {
            purchaseButton.enabled = false;
        }
    }
}
