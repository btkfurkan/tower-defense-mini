using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs; // prefabs olarak d��man�m�z
    [SerializeField] private Transform spawnPos; // d��manlar� olu�turaca��m�z yer



    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1.0f, Random.Range(1, 2));
    }

    private void Spawn()
    {
        Instantiate(enemyPrefabs, enemyPrefabs.transform.position, Quaternion.identity); // Olu�turulacak obje, pozisyonu ve rotasyonunu aynen al�yoruz.

    }
}
