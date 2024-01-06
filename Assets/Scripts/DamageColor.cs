using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColor : MonoBehaviour
{

    GameObject enemy;
    BossChar bossObj;
    int hpCompare;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        hpCompare = 10;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        bossObj = enemy.GetComponent<BossChar>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hpCompare > bossObj.hp)
        {
            hpCompare -= 1;
            StartCoroutine(waitColorChange());
            
        }
    }

    IEnumerator waitColorChange()
    {
        spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds((float)0.2);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
