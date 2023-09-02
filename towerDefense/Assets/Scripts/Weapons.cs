using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float fireRate; // bu deðer kadar örneðin 2 saniye de bir etrafý tarayacak
    public float attackRadius; // bu deðer kadar tarama yapacaðýz

    public BulletController bulletPrefabs;

    private Collider[] enemies;

    private Enemy currentEnemy = null; // mevcut düþman yani bize en yakýn düþman olacak

    void Start()
    {
        InvokeRepeating(nameof(ScanArea), 0, fireRate);
    }
    private void OnDrawGizmos()  // sahne görünümünde yaptýðým þeyleri bazý þeyleri görsel olarak gösterebilen bir class 
    {
        Gizmos.color = Color.yellow; // taraycaðý alanýn rengi, daha iyi anlamak için
        Gizmos.DrawWireSphere(transform.position, attackRadius);  // bulunduðu pozisyondan attackRadiusa kadar tarama(Merkezi ve yarýçapý olan bir tel kafes küre çizer.)

    }
    private void ScanArea()
    {
        float distance = 90; // büyük bir mesafe
        enemies = Physics.OverlapSphere(transform.position, attackRadius); // görülen sarý alanýn içerisinde neyin collider ý varsa onlarý bulmamýza yarýyor.

        foreach (Collider enemy in enemies) //çünkü çarptýðýmýz collider düþman olmayabilir
        {
            if (enemy.gameObject.TryGetComponent(out Enemy enemyScript)) // Enemy adlý scripti varsa o düþmandýr þeklinde düþündük
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position); // silahla düþman arasýndaki mesafeyi ölçüyoruz
                if (dist <= distance) // eðer 90 da biri varsa bana en yakýn düþman o dur. Bir tur daha döndü diyelim düþman 80 e geldi ve yeni düþman o olur
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
        if (currentEnemy) // currentEnemy varsa ona doðru bakýcaz
        {
            Vector3 direction = currentEnemy.transform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction); // oraya doðru bakýyor diye düþünebiliriz LookAt gibi 
        }
    }
}
