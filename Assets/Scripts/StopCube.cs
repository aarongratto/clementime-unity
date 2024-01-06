using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCube : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "pushable"){
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ground");
            col.gameObject.layer = LayerIgnoreRaycast;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
