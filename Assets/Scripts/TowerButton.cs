using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;

    [SerializeField]
    private TMPro.TextMeshProUGUI costText;

    private TowerData towerData;

    public void SetTowerData(TowerData towerData)
    {
        this.towerData = towerData;
        icon.sprite = towerData.icon;
        nameText.text = towerData.name;
        costText.text = towerData.cost.ToString();
    }

    public void OnClick()
    {
        BuildingManager.Instance.selectedTowerData = towerData;
    }
}
