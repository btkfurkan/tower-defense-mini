using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float fireRate; // bu de�er kadar �rne�in 2 saniye de bir etraf� tarayacak
    public float attackRadius; // bu de�er kadar tarama yapaca��z

    public BulletController bulletPrefabs;

    private Collider[] enemies;

    private Enemy currentEnemy = null; // mevcut d��man yani bize en yak�n d��man olacak

    void Start()
    {
        InvokeRepeating(nameof(ScanArea), 0, fireRate);
    }
    private void OnDrawGizmos()  // sahne g�r�n�m�nde yapt���m �eyleri baz� �eyleri g�rsel olarak g�sterebilen bir class 
    {
        Gizmos.color = Color.yellow; // tarayca�� alan�n rengi, daha iyi anlamak i�in
        Gizmos.DrawWireSphere(transform.position, attackRadius);  // bulundu�u pozisyondan attackRadiusa kadar tarama(Merkezi ve yar��ap� olan bir tel kafes k�re �izer.)

    }
    private void ScanArea()
    {
        float distance = 90; // b�y�k bir mesafe
        enemies = Physics.OverlapSphere(transform.position, attackRadius); // g�r�len sar� alan�n i�erisinde neyin collider � varsa onlar� bulmam�za yar�yor.

        foreach (Collider enemy in enemies) //��nk� �arpt���m�z collider d��man olmayabilir
        {
            if (enemy.gameObject.TryGetComponent(out Enemy enemyScript)) // Enemy adl� scripti varsa o d��mand�r �eklinde d���nd�k
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position); // silahla d��man aras�ndaki mesafeyi �l��yoruz
                if (dist <= distance) // e�er 90 da biri varsa bana en yak�n d��man o dur. Bir tur daha d�nd� diyelim d��man 80 e geldi ve yeni d��man o olur
                {
                    currentEnemy = enemyScript;
                    distance = dist;
                }
            }

        }

        if (currentEnemy) //Tarama bittikten sonra currentEnemy varsa
        {
            Vector3 bullerPos = new Vector3(transform.position.x, 0.4f, transform.position.z);
            BulletController bullet = Instantiate(bulletPrefabs, bullerPos, Quaternion.identity);
            bullet.SetTarget(currentEnemy.transform);
        }

    }

    void Update()
    {
        if (currentEnemy) // currentEnemy varsa ona do�ru bak�caz
        {
            Vector3 direction = currentEnemy.transform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction); // oraya do�ru bak�yor diye d���nebiliriz LookAt gibi 
        }
    }
}
