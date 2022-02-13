using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    public TextMeshProUGUI coinDisplayTex;
    public int currentCoins = 10;


    // Start is called before the first frame update
    void Start()
    {
        coinDisplayTex.text = "" + PlayerPrefs.GetInt("Coin");
        if (PlayerPrefs.HasKey("Coin"))
        {
            currentCoins = PlayerPrefs.GetInt("Coin");
        }
        else
        {

        }
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Coin")
        {
            // Destroy(other.gameObject);
            // other.gameObject.SetActive(false);
            
        }
    }

    public void ClaimCoins()
    {
        currentCoins += 2;
        PlayerPrefs.SetInt("Coin", currentCoins);
        coinDisplayTex.text = "" + currentCoins;
    }
}
