using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs; // prefabs olarak düþmanýmýz
    [SerializeField] private Transform spawnPos; // düþmanlarý oluþturacaðýmýz yer



    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1.0f, Random.Range(1, 2));
    }

    private void Spawn()
    {
        Instantiate(enemyPrefabs, enemyPrefabs.transform.position, Quaternion.identity); // Oluþturulacak obje, pozisyonu ve rotasyonunu aynen alýyoruz.

    }
}
