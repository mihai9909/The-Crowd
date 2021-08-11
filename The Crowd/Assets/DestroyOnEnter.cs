using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnter : MonoBehaviour
{
    ClonesManager cManager;
    private void Awake()
    {
        cManager = GameObject.FindGameObjectWithTag("CloneManager").GetComponent<ClonesManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("collided with: " + collision.gameObject.name);
            Destroy(gameObject);
            cManager.nrClones = cManager.nrClones - 1;
        }
    }
}
