using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private static BuildingManager instance;

    public static BuildingManager Instance => instance;

    private Camera camera;

    [SerializeField]
    private LayerMask constructionLayerMask;

    [HideInInspector]
    public TowerData selectedTowerData = null;

    private void Awake()
    {
        instance = this;
        camera = Camera.main;
    }

    public void Update()
    {
        if (selectedTowerData == null) return;

        if(Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            var hit = Physics2D.Raycast(ray.origin, ray.direction, 15, constructionLayerMask);
            if(hit.collider != null)
            {
                BuildTower(hit.point);
            } else
            {
                Debug.Log("Kliknul jsi mimo...");
            }

            selectedTowerData = null;
        }
    }

    private void BuildTower(Vector3 position)
    {
        if (selectedTowerData.prefab == null) return;

        var g = Instantiate(selectedTowerData.prefab, position, Quaternion.identity);
    }
}
