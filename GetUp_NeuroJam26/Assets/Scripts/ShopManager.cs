using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField] GameObject progressBar;
    [SerializeField] GameObject character;

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

    public void UpgradeIndex9()
    {
        character.GetComponent<Animator>().SetBool("SittingUp", true);
    }
}
