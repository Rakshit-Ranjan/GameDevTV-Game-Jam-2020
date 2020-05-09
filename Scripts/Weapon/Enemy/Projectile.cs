using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform playerTransform;

    public float speed;

    private Rigidbody2D rb;

    private Vector2 target;

    public float lifeTime;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, lifeTime);
        target = playerTransform.position;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update() {
        rb.position = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        if(rb.position == target) {
            Destroy(gameObject);
        }
        
    }
}
