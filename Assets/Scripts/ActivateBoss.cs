using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour
{
    public GameObject Boss;
    public GameObject strawDeactivate;

    private bool onlyOnce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !onlyOnce)
        {
            onlyOnce = true;
            Boss.SetActive(true);
            strawDeactivate.SetActive(false);
        }
    }
}
