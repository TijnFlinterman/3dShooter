using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Spawn : MonoBehaviour
{
    public static E_Spawn Instance { get; private set; }
    public GameObject eCube;
    public GameObject[] eCubes;
    int numEnemies;

    GameObject player;

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

    void Start()
    {
        player = E_Spawn.Instance.player;
        numEnemies = 50;
        eCubes = new GameObject[numEnemies];
        for (int i = 0; 1 < eCubes.Length; i+= 5)
        {
            GameObject e=Instantiate(eCube, new Vector3(i + 565- 10, 4, 433), Quaternion.identity) as GameObject;
            eCubes[i] = e; 
        }
        eCubes[1].transform.Translate(0, 1, 0);
    }
}
