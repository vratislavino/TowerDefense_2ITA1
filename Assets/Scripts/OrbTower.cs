using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTower : Tower
{
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float range;

    [SerializeField] private Transform orbReference;

    // Start is called before the first frame update
    void Start()
    {
        var orb = orbReference.GetChild(0);
        orb.localPosition = new Vector3(range, 0, 0);

        GetComponentInChildren<OrbCollision>().SetDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        orbReference.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
