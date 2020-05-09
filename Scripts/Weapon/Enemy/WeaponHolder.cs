using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    public EnemyWeapon weapon;

    public EnemyWeapon spawnedWeapon;

    public float size;

    public bool isBoss;

    private void Awake() {
        if(!isBoss)
            spawnedWeapon = Instantiate(weapon, GetComponentInParent<SlashEnemy>().transform.position, Quaternion.identity);
        else
            spawnedWeapon = Instantiate(weapon, GetComponentInParent<BossOgre>().transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
    }

    private void Update() {
        spawnedWeapon.transform.localScale = new Vector3(size, size, size);        
    }
}
