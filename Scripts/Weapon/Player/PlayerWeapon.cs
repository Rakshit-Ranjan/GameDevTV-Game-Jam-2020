using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public float startTimeBtwAttack;

    public WeaponAttackType attackType;

    private float timeBtwAttack;

    public WeaponType weaponType;

    public float damage;

    public float attackSpeed;

    private Vector2 mousePos;

    public Transform placePoint;

    public PlayerMovement player;

    public bool canAttack;

    public Vector2 orgPos;

    private void Start() {
        canAttack = false;
        player = GetComponentInParent<PlayerMovement>();
        timeBtwAttack = startTimeBtwAttack;
    }

    private void Update() {
        orgPos = placePoint.position;
        Rotate();
        
        if (timeBtwAttack <= 0) {
            if (Input.GetMouseButtonDown(0)) {
                if (attackType == WeaponAttackType.Slash)
                    StartCoroutine(SlashAttack());
                if (attackType == WeaponAttackType.Spin) {
                    StartCoroutine(SpinAttack(2f));
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }

    public void Rotate() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (Vector2) transform.position - mousePos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public IEnumerator SlashAttack() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        Vector2 targetPos = hit.point;

        float percent = 0;

        while (percent <= 1) {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(orgPos, targetPos, formula);
            yield return null;
        }       
    }

    public IEnumerator SpinAttack(float duration) {
        float timeBtwFrames = duration / 360;
        Vector3 org = transform.localEulerAngles;
        for(int i = 360; i >= 1; i -= 45) {
            org.z = i;
            transform.localEulerAngles = org;
            yield return new WaitForSeconds(timeBtwFrames);
        }
    }

}
