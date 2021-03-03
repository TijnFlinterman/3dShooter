using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    public GameObject enemyManager;
    public GameObject medManager;


    public List<int> inventory = new List<int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1") && inventory[0] != 0)
        {
            GameManager.Instance.player.GetComponent<P_Health>().Medkit(inventory[0]);
            GameManager.Instance.player.GetComponent<P_Health>().bandag();
            inventory[0] = 0;
        }
        if (Input.GetKeyDown("2") && inventory[1] != 0)
        {
            GameManager.Instance.player.GetComponent<P_Health>().Medkit(inventory[1]);
            inventory[1] = 0;
        }
        if (Input.GetKeyDown("3") && inventory[2] != 0)
        {
            GameManager.Instance.player.GetComponent<P_Health>().Medkit(inventory[2]);
            inventory[2] = 0;
        }
        if (Input.GetKeyDown("4") && inventory[3] != 0)
        {
            GameManager.Instance.player.GetComponent<P_Health>().Medkit(inventory[3]);
            inventory[3] = 0;
        }
    }
}
