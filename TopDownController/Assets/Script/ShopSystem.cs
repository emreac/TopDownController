using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;  

public class ShopSystem : MonoBehaviour
{
    //Character Price Controller
    public CharBlueprint[] charBlueprint;
    public Button buyButton;


 //   public AudioSource buttonBeep;
    public int currentCharIndex;
    public GameObject[] charModels;
    // Start is called before the first frame update
    void Start()
    {

        //Chars is Locked First
        foreach (CharBlueprint c in charBlueprint)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;

        }




        currentCharIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in charModels)
            character.SetActive(false);


        charModels[currentCharIndex].SetActive(true);
  
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardRight();

        UpdateUI();
    }

    public void KeyboardRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextChar();
        }
    }

    public void NextChar()
    {
       // ButtonSound();
        charModels[currentCharIndex].SetActive(false);

        currentCharIndex++;
        if (currentCharIndex == charModels.Length)
            currentCharIndex = 0;

        charModels[currentCharIndex].SetActive(true);
        CharBlueprint b = charBlueprint[currentCharIndex];
        if (!b.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedChar", currentCharIndex);

    }
    public void PreviousChar()
    {
       // ButtonSound();
        charModels[currentCharIndex].SetActive(false);

        currentCharIndex--;
        if (currentCharIndex == -1)
            currentCharIndex = charModels.Length - 1;

        charModels[currentCharIndex].SetActive(true);
        CharBlueprint b = charBlueprint[currentCharIndex];
        if (!b.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedChar", currentCharIndex);

    }

    //UNLOCK CHAR
    public void UnlockChar()
    {
        CharBlueprint b = charBlueprint[currentCharIndex];
        PlayerPrefs.SetInt(b.name, 1);
        PlayerPrefs.SetInt("SelectedChar", currentCharIndex);
        b.isUnlocked = true;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) - b.price);


    }


    public void ButtonSound()
    {
       // buttonBeep.Play();
    }

    private void UpdateUI()
    {
        CharBlueprint b = charBlueprint[currentCharIndex];
        if (b.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Get" + b.price;
            if (b.price < PlayerPrefs.GetInt("Coin", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;

            }
        }
    }


}
