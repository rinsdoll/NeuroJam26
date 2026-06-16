using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    [SerializeField] GameObject[] characterParts;
    [SerializeField] TextMeshProUGUI hairToggleButtonText;
    int randomInt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        randomInt = Random.Range(0, 1);
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

    }

    public void ToggleHair()
    {
        if (characterParts[2].activeSelf)
        {
            characterParts[2].SetActive(false);
            characterParts[3].SetActive(true);
            hairToggleButtonText.text = "Masc";
        }
        else if (characterParts[3].activeSelf)
        {
            characterParts[3].SetActive(false);
            characterParts[2].SetActive(true);
            hairToggleButtonText.text = "Fem";
        }
    }
}
