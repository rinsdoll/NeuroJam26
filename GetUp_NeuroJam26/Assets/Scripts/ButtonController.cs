using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;

    [Header("Get Up Value Control")]
    public int value = 0;
    public int increaseAmount = 1;
    public int goalValue = 100;
    float reductionRate = 1f;
    float progressTreshold = 0;
    [SerializeField] TextMeshProUGUI valueText_Temp;
    [SerializeField] Button brainButton;
    bool gameWon = false;
    [SerializeField] GameObject winImage;
    [SerializeField] GameObject confettii;
    [SerializeField] GameObject confettii2;

    [Header("Progress Bar")]
    float fillPercentage;
    [SerializeField] Image fillBarImage;

    [Header("Coins")]
    public int coins = 0;
    public int coinIncreaseAmount = 1;
    [SerializeField] TextMeshProUGUI coinText;

    [Header("Settings")]
    [SerializeField] GameObject settingsCanvas;
    public bool settingsActive = false;
    [SerializeField] Button settingsButton;

    [Header("Shop")]
    [SerializeField] GameObject shopCanvas;
    bool shopActive = false;
    [SerializeField] Button shopButton;
    public GameObject[] shopItems;

    [Header("Shop Effects")]
    public bool catActive = false;
    public bool importantActive = false;
    public bool hungryActive = false;
    public bool bathroomActive = false;
    public bool spontaniousThoughtActive = false;
    int spontaniousValue;
    int spontaniousMatch;

    [Header("Tutorial")]
    [SerializeField] GameObject[] tutorials;
    bool shopTutorialCompleted;
    bool settingsTutorialCompleted;



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
        spontaniousValue = Random.Range(0, 2);
    }

    
    void Update()
    {
        if (value < 0)
        {
            value = 0;
        }
        if (value >= 5 && !shopTutorialCompleted)
        {
            tutorials[1].SetActive(true);
        }
        if (value >= 20 && !settingsTutorialCompleted)
        {
            tutorials[2].SetActive(true);
        }

        if (value >= goalValue)
        {
            WinGame();
        }

    }

    public void IncreaseValue()
    {
        tutorials[0].SetActive(false);
        value += increaseAmount;

        if (spontaniousThoughtActive)
        {
            RollSpontanious();
            if (spontaniousValue == spontaniousMatch)
            {
                WinGame() ;
            }
        }

        valueText_Temp.text = value.ToString();
        if (catActive)
        {
            coinIncreaseAmount = Random.Range(2, 6);
        }
        coins += coinIncreaseAmount;
        coinText.text = coins.ToString();

        UpdateFillBar();

        if(value > progressTreshold + 5)
        {
            StartCoroutine(ReduceValueOverTime(reductionRate));
        }
    }

    IEnumerator ReduceValueOverTime(float seconds)
    {
        while (value >= progressTreshold + 2)
        {
            yield return new WaitForSeconds(seconds);
            if (value > Mathf.Floor(progressTreshold))
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

    public void UpdateReductionRate(int reductionCase)
    {
        switch (reductionCase)
        {
            case 0: //catActive
                reductionRate *= 0.5f;
                break;
            case 1: //tVActive
                reductionRate *= 2f;
                break;
            case 2: //booksActive
                reductionRate *= 2.5f;
                break;
            case 3: //artActive
                reductionRate *= 2.75f;
                break;
            default:
                break;
        }

    }

    public void UpdateValueRate(int increaseValue)
    {
        switch (increaseValue)
        {
            case 0: //Important
                increaseAmount += 1;
                break;
            case 1: //Hungry
                increaseAmount += 1;
                break;
            case 2: //Bathroom
                increaseAmount += 2;
                break;
            default :
                break;
        }
    }

    public void UpdateProgressThreshold (int threshold)
    {
        switch (threshold)
        {
            case 0: //Sit up
                progressTreshold += (goalValue * .1f);
                break;
            case 1: //Spikes
                progressTreshold += (goalValue * .15f);
                break;
            case 2: //Sunny day
                progressTreshold += (goalValue * .2f);
                break;
            default:
                break;
        }
    }


    
    public void ToggleSettings()
    {
        if (!settingsTutorialCompleted)
        {
            settingsTutorialCompleted = true;
            tutorials[2].SetActive(false);
        }
        if (settingsActive)
        {
            settingsCanvas.SetActive(false);
            settingsActive = false;
            shopButton.enabled = true;
            if (!gameWon)
            {
                brainButton.enabled = true;
            }
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
        if (!shopTutorialCompleted)
        {
            shopTutorialCompleted = true;
            tutorials[1].SetActive(false);
        }
        if (shopActive)
        {
            shopCanvas.SetActive(false);
            shopActive = false;
            settingsButton.enabled = true;
            if (!gameWon)
            {
                brainButton.enabled = true;
            }
            
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

    void RollSpontanious()
    {
        spontaniousMatch = Random.Range(0, 2);
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        gameWon = true;
        CharacterManager.instance.StandUp();
        brainButton.enabled = false;
        winImage.SetActive(true);
        ShopManager.instance.MoveCat();
        confettii.GetComponent<ParticleSystem>().Play();
        confettii2.GetComponent<ParticleSystem>().Play();

    }
}
