using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingKnives : MonoBehaviour
{   
    Rigidbody2D rb;
    public float gravity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag.Equals("Player")){
            rb.isKinematic = false;
            rb.gravityScale = gravity;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag.Equals("Ground") | col.gameObject.tag.Equals("Player")){
            Destroy(gameObject);
        }
    }
}
