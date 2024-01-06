using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobChar : MonoBehaviour
{

    public int hp;
    GameObject enemy;
    GameObject player;
    SpriteRenderer spriteRenderer;
    [SerializeField] private int distance;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        enemy = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we kill the enemy, hide it from scene
        if (hp == 0)
        {
            PlayerScore.increaseScore(100);
            enemy.SetActive(false);
        }

        if (Input.GetKeyUp("f"))
        {
            
            float distanceFromEnemy = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (distanceFromEnemy < distance)
            {
                PlayerScore.increaseScore(10);
                MobChar enemyObj = enemy.GetComponent<MobChar>();
                enemyObj.damage(1);
            }
        }
    }



    public int getHP()
    {
        return hp;
    }

    //decrease HP of enemy
    public void damage(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
        StartCoroutine(waitColorChange());
        
    }

    IEnumerator waitColorChange()
    {
        spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds((float)0.2);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    //heal by specified amount (not for gameplay, used for testing)
    public void heal(int heal)
    {
        hp += heal;
    }
}
