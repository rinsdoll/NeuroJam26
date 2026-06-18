using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [Header("Character")]
    [SerializeField] GameObject[] characterParts;
    bool sittingUp = false;
    bool standingUp = false;

    [Header("Customizations")]
    [SerializeField] Slider skinR;
    [SerializeField] Slider skinG;
    [SerializeField] Slider skinB;

    [SerializeField] Slider shirtR;
    [SerializeField] Slider shirtG;
    [SerializeField] Slider shirtB;

    [SerializeField] Slider hairR;
    [SerializeField] Slider hairG;
    [SerializeField] Slider hairB;

    [Header ("Hair")]
    [SerializeField] TextMeshProUGUI hairToggleButtonText;
    int randomInt;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        randomInt = Random.Range(0, 2);
        if(randomInt == 0)
        {
            characterParts[2].SetActive(false);
            characterParts[3].SetActive(true);
            hairToggleButtonText.text = "Masc";
        }
        else
        {
            characterParts[3].SetActive(false);
            characterParts[2].SetActive(true);
            hairToggleButtonText.text = "Fem";
        }
    }

    public void SitUp()
    {
        for (int i = 0; i < characterParts.Length; i++)
        {
            if (i == 1)
            {
                characterParts[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            characterParts[i].GetComponent<Animator>().SetBool("SittingUp", true);
        }
        sittingUp = true;
        SyncAnimations();

    }

    public void StandUp()
    {
        for (int i = 0; i < characterParts.Length; i++)
        {
            if (i == 1)
            {
                characterParts[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            characterParts[i].GetComponent<Animator>().SetBool("StandingUp", true);
        }
        sittingUp = false;
        standingUp = true;
        SyncAnimations();

    }

    public void ToggleHair()
    {
        if (characterParts[2].activeSelf)
        {
            characterParts[2].SetActive(false);
            characterParts[3].SetActive(true);
            if (sittingUp)
            {
                characterParts[3].GetComponent<Animator>().SetBool("SittingUp", true);
            }
            else if (standingUp)
            {
                characterParts[3].GetComponent<Animator>().SetBool("StandingUp", true);
            }
            hairToggleButtonText.text = "Masc";
            SyncAnimations();
        }
        else if (characterParts[3].activeSelf)
        {
            characterParts[3].SetActive(false);
            characterParts[2].SetActive(true);
            hairToggleButtonText.text = "Fem";
            if (sittingUp)
            {
                characterParts[2].GetComponent<Animator>().SetBool("SittingUp", true);
            }
            else if (standingUp)
            {
                characterParts[2].GetComponent<Animator>().SetBool("StandingUp", true);
            }
            hairToggleButtonText.text = "Fem";

            SyncAnimations();
        }
    }

    public void SyncAnimations()
    {
        for(int i = 0; i < characterParts.Length; i++)
        {
            characterParts[i].GetComponent<Animator>().Play(0, -1, 0);
        }
    }

    private void Start()
    {
        hairR.value = Random.Range(0f, 1f);
        hairG.value = Random.Range(0f, 1f);
        hairB.value = Random.Range(0f, 1f);

        shirtR.value = Random.Range(0f, 1f);
        shirtG.value = Random.Range(0f, 1f);
        shirtB.value = Random.Range(0f, 1f);

        characterParts[0].GetComponent<SpriteRenderer>().material.color = new Color(skinR.value, skinG.value, skinB.value);
        characterParts[1].GetComponent<SpriteRenderer>().material.color = new Color(skinR.value, skinG.value, skinB.value);

        characterParts[2].GetComponent<SpriteRenderer>().material.color = new Color(hairR.value, hairG.value, hairB.value);
        characterParts[3].GetComponent<SpriteRenderer>().material.color = new Color(hairR.value, hairG.value, hairB.value);

        characterParts[4].GetComponent<SpriteRenderer>().material.color = new Color(shirtR.value, shirtG.value, shirtB.value);
    }


    private void Update()
    {
        if (ButtonController.instance.settingsActive)
        {
            characterParts[0].GetComponent<SpriteRenderer>().material.color = new Color(skinR.value, skinG.value, skinB.value);
            characterParts[1].GetComponent<SpriteRenderer>().material.color = new Color(skinR.value, skinG.value, skinB.value);

            characterParts[2].GetComponent<SpriteRenderer>().material.color = new Color(hairR.value, hairG.value, hairB.value);
            characterParts[3].GetComponent<SpriteRenderer>().material.color = new Color(hairR.value, hairG.value, hairB.value);

            characterParts[4].GetComponent<SpriteRenderer>().material.color = new Color(shirtR.value, shirtG.value, shirtB.value);
        }

    }
    
}
