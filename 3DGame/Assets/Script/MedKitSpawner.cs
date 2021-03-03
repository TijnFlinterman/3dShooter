using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitSpawner : MonoBehaviour
{
    public static MedKitSpawner Instance { get; private set; }
    public GameObject medPack;
    public GameObject[] medPacks;
    private float ranX;
    private float ranZ;

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
        medPacks = new GameObject[3];

        for (int i = 0; 1 < 4; i++)
        {
            ranX = Random.Range(530, 480);
            ranZ = Random.Range(460, 410);
            GameObject m = Instantiate(medPack, new Vector3(ranX - 1, 3, ranZ), Quaternion.identity) as GameObject;
            m.GetComponent<Medkit>().SetHeal(i + 1);
            medPacks[i] = m;
        }
    }
}
