using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField] GameObject[] shopItems;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpgradeIndex0() //ProgressBar
    {
        shopItems[0].SetActive(true);
    }

    public void UpgradeIndex1() //Spontanious
    {
        //CharacterManager.instance.StandUp();
    }

    public void UpgradeIndex2() //Cat
    {
        ButtonController.instance.catActive = true;
        ButtonController.instance.UpdateReductionRate(0);
        shopItems[1].SetActive(true);
    }

    public void UpgradeIndex3() //TV
    {
        
        ButtonController.instance.UpdateReductionRate(1);
        shopItems[2].SetActive(true);
    }

    public void UpgradeIndex4() //Books
    {
        
        ButtonController.instance.UpdateReductionRate(2);
        shopItems[3].SetActive(true);
    }

    public void UpgradeIndex5() //Art
    {
        ButtonController.instance.UpdateReductionRate(3);
        shopItems[4].SetActive(true);
    }

    public void UpgradeIndex6() //Important
    {
        if (shopItems[6].activeSelf || shopItems[7].activeSelf)
        {
            shopItems[6].SetActive(false);
            shopItems[7].SetActive(false);
        }
        ButtonController.instance.UpdateValueRate(0);
        shopItems[5].SetActive(true);
    }

    public void UpgradeIndex7() //Hungry
    {
        if (shopItems[5].activeSelf || shopItems[7].activeSelf)
        {
            shopItems[5].SetActive(false);
            shopItems[7].SetActive(false);
        }
        ButtonController.instance.UpdateValueRate(1);
        shopItems[6].SetActive(true);
    }

    public void UpgradeIndex8() //Bathroom
    {
        if (shopItems[5].activeSelf || shopItems[6].activeSelf)
        {
            shopItems[5].SetActive(false);
            shopItems[6].SetActive(false);
        }
        ButtonController.instance.UpdateValueRate(2);
        shopItems[7].SetActive(true);
    }

    public void UpgradeIndex9() //Sit Up
    {
        ButtonController.instance.UpdateProgressThreshold(0);
        CharacterManager.instance.SitUp();
    }

    public void UpgradeIndex10() //Spikes
    {
        ButtonController.instance.UpdateProgressThreshold(1);
        shopItems[8].SetActive(true);
    }
    public void UpgradeIndex11() //Sunny Day
    {
        ButtonController.instance.UpdateProgressThreshold(2);
        shopItems[9].SetActive(true);
    }

}
