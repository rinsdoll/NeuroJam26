using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;

    [Header("Get Up Value Control")]
    public int value = 0;
    public int increaseAmount = 1;
    public int goalValue = 100;
    float reductionRate = 1f;
    [SerializeField] TextMeshProUGUI valueText_Temp;
    [SerializeField] Button brainButton;

    [Header("Progress Bar")]
    float fillPercentage;
    [SerializeField] Image fillBarImage;

    [Header("Coins")]
    public int coins = 0;
    public int coinIncreaseAmount = 1;
    [SerializeField] TextMeshProUGUI coinText;

    [Header("Settings")]
    [SerializeField] GameObject settingsCanvas;
    bool settingsActive = false;
    [SerializeField] Button settingsButton;

    [Header("Shop")]
    [SerializeField] GameObject shopCanvas;
    bool shopActive = false;
    [SerializeField] Button shopButton;
    public GameObject[] shopItems;

    //[Header("SFX")]
    //[SerializeField] GameObject sxfManager;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        coinText.text = coins.ToString();
    }

    
    void Update()
    {
        if (value < 0)
        {
            value = 0;
        }
    }

    public void IncreaseValue()
    {
        value += increaseAmount;
        valueText_Temp.text = value.ToString();
        coins += coinIncreaseAmount;
        coinText.text = coins.ToString();

        UpdateFillBar();

        if(value > 5)
        {
            StartCoroutine(ReduceValueOverTime(reductionRate));
        }
    }

    IEnumerator ReduceValueOverTime(float seconds)
    {
        while (value >= 2)
        {
            yield return new WaitForSeconds(seconds);
            if (value > 0)
            {
                value--;
                valueText_Temp.text = value.ToString();
                UpdateFillBar();
            } 
        }
    }

    void UpdateFillBar()
    {
        fillPercentage = (float)value / goalValue;
        fillBarImage.GetComponent<Image>().fillAmount = fillPercentage;
    }


    
    public void ToggleSettings()
    {
        if (settingsActive)
        {
            settingsCanvas.SetActive(false);
            settingsActive = false;
            shopButton.enabled = true;
            brainButton.enabled = true;
        }
        else
        {
            settingsCanvas.SetActive(true);
            settingsActive = true;
            shopButton.enabled = false;
            brainButton.enabled = false;
        }
    }

    public void ToggleShop()
    {
        if (shopActive)
        {
            shopCanvas.SetActive(false);
            shopActive = false;
            settingsButton.enabled = true;
            brainButton.enabled = true;

            for (int i = 0; i < 12; i++)
            {
                if (shopItems[i] != null)
                {
                    //Debug.Log(shopItems[i].GetComponent<ShopItem>().descriptionActive);
                    if (shopItems[i].GetComponent<ShopItem>().descriptionActive)
                    {
                        shopItems[i].GetComponent<ShopItem>().ToggleDescription();
                    }
                }

            }
        }
        else
        {
            shopCanvas.SetActive(true);
            shopActive = true;
            settingsButton.enabled = false;
            brainButton.enabled = false;
        }
    }

    public void SpendCoins(int itemCost)
    {
        coins = coins - itemCost;
        coinText.text = coins.ToString();
    }

    public void ToggleAllButtonsDescription()
    {
        for (int i = 0; i < 12; i++)
        {
            if (shopItems[i] != null)
            {
                //Debug.Log(shopItems[i].GetComponent<ShopItem>().descriptionActive);
                if (shopItems[i].GetComponent<ShopItem>().descriptionActive)
                {
                    shopItems[i].GetComponent<ShopItem>().ToggleDescription();
                    shopItems[i].GetComponent<ShopItem>().purchaseButton.GetComponent<Purchase>().saleIndex = -1;
                }
            }

        }
    }
}
