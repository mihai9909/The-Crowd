using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtractor : MonoBehaviour
{
    int subNr = 20;
    TextMesh text;

    private void Awake()
    {
        text = gameObject.GetComponentInChildren<TextMesh>();
    }
    private void Update()
    {
        text.text = ""+subNr;
    }

    private void OnCollisionEnter(Collision other)
    {
        print(subNr);
        if (other.gameObject.tag == "Player")
            subNr--;
        if(subNr <= 0)
            Destroy(gameObject);
    }
}
