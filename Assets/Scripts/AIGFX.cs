using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIGFX : MonoBehaviour
{
    public AIPath aipath;
    // Update is called once per frame
    void Update()
    {
        //Just flipping based on speed, if positive we are going right, if negative we are going left
        //Travelling right, flip sprite
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        }
        //Travelling left, flip sprite
        else if (aipath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1f);
        }
    }
}
