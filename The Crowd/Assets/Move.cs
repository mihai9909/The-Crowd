using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 move;
    public float forwardSpeed;
    public GameObject Clone;

    public int nrPlayers;

    Rigidbody RB;
    ClonesManager cloneManager;
    bool start = false;
    void Start()
    {

        start = false;
        cloneManager = GameObject.FindGameObjectWithTag("CloneManager").GetComponent<ClonesManager>();
        if (cloneManager == null)
            Debug.LogError("Clone Manager not found");

        RB = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {   
        if(start)
            transform.position += new Vector3(0f,0f,forwardSpeed) * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            start = true;
            Touch touch = Input.GetTouch(0);
            // Handle finger movements based on TouchPhase
            if (touch.phase == TouchPhase.Moved)
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        nrPlayers = cloneManager.nrClones;

        for(int i = 0;i<nrPlayers;i++)
        {
            if (transform.GetChild(i).position.x > 9.5f)
            {
                transform.position = new Vector3(9.5f - transform.GetChild(i).position.x + transform.position.x, transform.position.y, transform.position.z);
            }
            if (transform.GetChild(i).position.x < -9.5f)
            {
                transform.position = new Vector3(-9.5f - transform.GetChild(i).position.x + transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
