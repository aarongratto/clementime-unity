using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackAction : MonoBehaviour
{

    public GameObject straw;
    public GameObject juiceGun;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if(straw!= null)
            {
                straw.GetComponent<Animator>().Play("SwingStraw");
                straw.GetComponent<Animator>().Play("DefaultState");
            }
            else
            {
                juiceGun.GetComponent<Animator>().Play("RecoilGun");
                juiceGun.GetComponent<Animator>().Play("DefaultState");
                ParticleSystem juiceSquirter = juiceGun.GetComponentInChildren<ParticleSystem>();
                juiceSquirter.Play();
                

            }
            
        }
    }
}
