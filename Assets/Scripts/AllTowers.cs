using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "AllTowers", 
    menuName = "ScriptableObjects/AllTowers",
    order = 0)]
public class AllTowers : ScriptableObject
{
    public List<TowerData> allData;
}
