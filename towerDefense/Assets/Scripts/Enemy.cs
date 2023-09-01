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
        // Mesafeye göre hýz deðiþtiði için ve tekrar ayarlama yapýlmasý gerektiði için NavMesh kullanacaðým.
        /*var sequence = DOTween.Sequence();
        //foreach (Transform target in MapManager.Instance.controlPoints)
        //{

        //    sequence.Append(transform.DOMove(target.position, 1)); // sýra sýra belirtilen noktalarý takip edecek. bir sqnce nesnesi oluþturduk. Adým adým hareket edecektir.
        //                                                           // her eleman döndükçe bunu yapacak. 

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
