using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockLvl : MonoBehaviour
{
    GameObject Price;
    [SerializeField] private GameObject Level;
    [SerializeField] int price;
    [SerializeField] int numberOfLevel;
    private DataManager dataManager;
    private SavedData savedData;

    private void Start()
    {
        dataManager = new DataManager();
        savedData = dataManager.GetData();
        
        Price = transform.Find("price").gameObject;
        int.TryParse(Price.GetComponent<TMP_Text>().text, out price);
        int.TryParse(Level.name, out numberOfLevel);
        
        if (savedData.UnlockedLevels[numberOfLevel - 1])
        {
            Level.SetActive(true);
            gameObject.SetActive(false);
        }  
        else
        {
            Level.SetActive(false);
            gameObject.SetActive(true);
        }
    }

    public void  OnUnlock()
    {
        if (EventUnlockLvl.OnLvlUnlock(price))
        {
            savedData = dataManager.GetData();
            savedData.UnlockedLevels[numberOfLevel - 1] = true;
            dataManager.SaveData(savedData);

            for (int i = 0; i < 10; i++)
            {
                Debug.Log("Данные " + savedData.UnlockedLevels[i] + " уровня");
            }

            Level.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
