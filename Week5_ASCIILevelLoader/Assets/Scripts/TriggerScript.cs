using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // public GameManager gameManager;

    private ASCIILevelLoaderScript ASCIIScript;

    // public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        ASCIIScript = GameManager.instance.GetComponent<ASCIILevelLoaderScript>();
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Reached the end!");

        if (collision.gameObject.name.Contains("Player"))
        {
            if (ASCIIScript.CurrentLevel < 2)
            {
                Debug.Log("Next level!");
                ASCIIScript.CurrentLevel += 1;    
            }
            else
            {
                Debug.Log("Finished!");
            }
        }
    }
}
