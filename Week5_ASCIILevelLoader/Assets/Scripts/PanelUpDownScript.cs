using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUpDownScript : MonoBehaviour
{
    private float rotationSpdZ = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(Mathf.PingPong(rotationSpdZ * Time.time, 160) - 80, 0, 0);
    }
}
