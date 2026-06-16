using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField] GameObject progressBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpgradeIndex0()
    {
        progressBar.SetActive(true);
    }

    public void UpgradeIndex1()
    {
        CharacterManager.instance.StandUp();
    }

    public void UpgradeIndex9()
    {
        CharacterManager.instance.SitUp();
    }
}
