using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Add : MonoBehaviour
{
    public int addObj = 20,mulObj = 2;
    public GameObject Player;       
    public GameObject parent;       //parent of the little players
    public bool mode = false;       //false for add true for multiply

    public Vector3 textOffset;

    ClonesManager cManager;
    Used parentScript;

    public TextMesh text;
    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("ParentPlayer");  //find parent of Players
        parentScript = gameObject.GetComponentInParent<Used>();     //script in parent that stores the used variable
        cManager = GameObject.FindGameObjectWithTag("CloneManager").GetComponent<ClonesManager>();

        if (!mode)
            text.text = "+" + addObj;
        else
            text.text = "x" + mulObj;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !parentScript.used && !mode)
        {
            spawnPlayers(addObj);
            parentScript.used = true;
        }
        else if(other.gameObject.tag == "Player" && !parentScript.used && mode)
        {
            spawnPlayers(cManager.nrClones * (mulObj - 1));
            parentScript.used = true;
        }
    }

    void spawnPlayers(int nrPlayers)
    {
        for (int i = 0; i < nrPlayers; i++)
        {
            if (cManager.nrClones >= cManager.maxNrClones)
                continue;
            Vector3 myVector = new Vector3(parent.transform.position.x+UnityEngine.Random.Range(0f, 1f), parent.transform.position.y, parent.transform.position.z + UnityEngine.Random.Range(0f, 1f));
            GameObject aux = Instantiate(Player, myVector, parent.transform.rotation);
            aux.transform.parent = parent.transform;
            cManager.nrClones++;
        }
    }

}
