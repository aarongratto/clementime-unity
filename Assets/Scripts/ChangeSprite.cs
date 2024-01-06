using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite firstSprite;
    public Sprite secondSprite;
    public Sprite thirdSprite;
    public Sprite fourthSprite;
    GameObject player;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthSystem playerHP = player.GetComponent<HealthSystem>();
        hp = playerHP.getHP();

        if(hp == 4)
        {
            spriteRenderer.sprite = firstSprite;
        }
        else if(hp == 3)
        {
            spriteRenderer.sprite = secondSprite;
        }
        else if (hp == 2)
        {
            spriteRenderer.sprite = thirdSprite;
        }
        else
        {
            spriteRenderer.sprite = fourthSprite;
        }
    }
}
