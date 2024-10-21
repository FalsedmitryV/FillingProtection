using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GasStation : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private TextMeshPro _maxHealthPointsTxt;
    public GameObject GameOver;
    
    public void GetDamage()
    {
        _healthPoints -= 1;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _maxHealthPointsTxt.text = _healthPoints.ToString();

        if (_healthPoints <= 0)
        {
            Time.timeScale = 0.0f;
            GameOver.SetActive(true);
        }
    }
}
