using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform target;
    public float speed;

    public void SetTarget(Transform target)
    {
        this.target = target;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            transform.forward = dir;
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
