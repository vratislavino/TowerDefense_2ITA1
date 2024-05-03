using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingUI : MonoBehaviour
{
    [SerializeField]
    private AllTowers allTowers;

    [SerializeField]
    private TowerButton towerButtonPrefab;

    void Start()
    {
        foreach(var towerData in allTowers.allData)
        {
            var button = Instantiate(towerButtonPrefab, transform);
            button.SetTowerData(towerData);
        }
    }
}
