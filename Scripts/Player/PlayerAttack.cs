using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public PlayerWeapon[] weapons;

    public PlayerWeapon currentWeapon;

    private PlayerWeapon GetWeapon(PlayerWeapon[] weapons, WeaponType weaponType) {
        foreach(PlayerWeapon weapon in weapons) {
            if(weapon.weaponType == weaponType) {
                return weapon;
            }
        }
        return weapons[0];
    }

    private void Start() {
        weapons = GetComponentsInChildren<PlayerWeapon>();
        foreach (PlayerWeapon weapon in weapons) {
            weapon.gameObject.SetActive(false);
        }
        currentWeapon = weapons[0];
    }

    private void Update() {
        currentWeapon.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        WeaponIcon icon = other.GetComponent<WeaponIcon>();
        if(icon != null) {
            currentWeapon = null;
            currentWeapon = GetWeapon(weapons, icon.weaponType);
            Destroy(icon.gameObject);
            foreach (PlayerWeapon weapon in weapons) {
                if(weapon.weaponType != icon.weaponType)
                    weapon.gameObject.SetActive(false);
            }

        }
    }

}


// class