using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private DataManager dataManager;
    private SavedData savedData;
    [SerializeField] private Text _countOfPointTxt;
    [SerializeField] private int _countOfPoint;

    public int GetCountOfPoint()
    {
        return _countOfPoint;
    }
    private void Start()
    {
        dataManager = new DataManager();
        savedData = dataManager.GetData();
        _countOfPoint = savedData.point;
        UpdatePoint();
        EventDeathEnamy.EnemyDied += GetPoint;
        EventUnlockLvl.LvlUnlock += TakePoint;
    }
    void GetPoint()
    {
        if (_countOfPointTxt != null)
        {
            _countOfPoint++;
            UpdatePoint();
            SavePoint();
        }
    }

    bool TakePoint(int count)
    {
        if (_countOfPoint - count >= 0)
        {
            _countOfPoint -= count;
            SavePoint();
            UpdatePoint();
            return true;
        }
        else {Debug.Log("Не хватает"); return false; }
    }

    private void UpdatePoint()
    {
        _countOfPointTxt.text = _countOfPoint.ToString();
    }

    void SavePoint()
    {
        savedData = dataManager.GetData();
        savedData.point = _countOfPoint;
        dataManager.SaveData(savedData);
    }

    private void OnDestroy()
    {
        EventDeathEnamy.EnemyDied -= GetPoint;
        EventUnlockLvl.LvlUnlock -= TakePoint;
    }
}
