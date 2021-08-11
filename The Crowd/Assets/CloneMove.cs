using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMove : MonoBehaviour
{
    public float centralize = 2f;
    Rigidbody RB;
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float step = speed * Time.deltaTime;
        Vector3 direction = transform.parent.position - transform.position;
        direction.Normalize();
        RB.AddForce(direction*centralize);
    }
}
