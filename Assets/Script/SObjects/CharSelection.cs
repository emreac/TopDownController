using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelection : MonoBehaviour
{

    public BabyModel[] babyModels;
    public Transform babyHolder;
    private int currentChar;

    private List<GameObject> chars;

    void Start()
    {
        chars = new List<GameObject>();

        foreach(var model in babyModels){
            GameObject go = Instantiate(model.baby, babyHolder.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(babyHolder);
            chars.Add(go);
        }
        ShowCharFromList();
    }
    void ShowCharFromList()
    {
        chars[currentChar].SetActive(true);
    }
  
}
