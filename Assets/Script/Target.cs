using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float damage = 1f;
    float health = 5f;
    float distance;
    public float maxAllowedDistance = 20f;
    public Transform playerPos;
    public GameObject player;
    bool hasShot;
    RaycastHit hit;
    public float range = 6f;

    private void Start()
    {
        player = GameObject.Find("Player");
        hasShot = false;
        playerPos = GameObject.Find("Player").transform;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, playerPos.position);
        if (distance < maxAllowedDistance && hasShot == false)
        {
            player.GetComponent<P_Health>().TakeDamage(damage);
            hasShot = true;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
