using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        agent.SetDestination(MapManager.Instance.castle.position);
        // Mesafeye g�re h�z de�i�ti�i i�in ve tekrar ayarlama yap�lmas� gerekti�i i�in NavMesh kullanaca��m.
        /*var sequence = DOTween.Sequence();
        //foreach (Transform target in MapManager.Instance.controlPoints)
        //{

        //    sequence.Append(transform.DOMove(target.position, 1)); // s�ra s�ra belirtilen noktalar� takip edecek. bir sqnce nesnesi olu�turduk. Ad�m ad�m hareket edecektir.
        //                                                           // her eleman d�nd�k�e bunu yapacak. 

        */

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Castle"))
        {
            MapManager.Instance.DamageCastle();
            Destroy(this.gameObject);
        }
    }


}
