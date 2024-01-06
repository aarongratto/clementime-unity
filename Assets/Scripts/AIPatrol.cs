using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float speed;

    private bool movingLeft = true;
    public float distanceDown = 1f;
    public float distanceLeft = 0.2f;


    public Transform groundCheckPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        int layer_mask = LayerMask.GetMask ("Ground");
        int layer_mask_trap = LayerMask.GetMask ("Trap");
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheckPos.position, Vector2.down, distanceDown, layer_mask);
        RaycastHit2D wallInfo = Physics2D.Raycast (groundCheckPos.position, Vector2.left, distanceLeft, layer_mask); 
        RaycastHit2D trapInfo = Physics2D.Raycast (groundCheckPos.position, Vector2.left, distanceLeft, layer_mask_trap); 

        if(groundInfo.collider == false | wallInfo.collider == true | trapInfo.collider == true){
            if(movingLeft == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            } else{
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }
}
