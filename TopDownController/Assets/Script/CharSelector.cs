using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelector : MonoBehaviour
{
    public int currentCharIndex;
    public GameObject[] chars;
    // Start is called before the first frame update
    void Start()
    {
        currentCharIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in chars)
            character.SetActive(false);

        chars[currentCharIndex].SetActive(true);

    }
    public void StartGame()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void SettingButton()
    {
        SceneManager.LoadScene("ShopMenu");
    }
    public void Nextlevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

