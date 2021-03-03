using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public GameObject player;
    int healing = 1;

    public void SetHeal(int h)
    {
        healing = h;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.inventory.Add(healing);
        player.GetComponent<P_Health>().Pickup();
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
