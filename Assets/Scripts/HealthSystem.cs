using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int hp;
    GameObject player;
    GameObject enemy;
    BoxCollider2D playerCollider;
    SpriteRenderer spriteRenderer;
    bool iFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = 4;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //if we reach 0 hp, the player dies and must reload the level
        if (hp == 0)
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }

        if (Input.GetKeyUp("f"))
        {
            
            float distanceFromEnemy = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (distanceFromEnemy < 5)
            {
                PlayerScore.increaseScore(10);
                BossChar enemyHP = enemy.GetComponent<BossChar>();
                enemyHP.damage(1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !iFrame)
        {
            HealthSystem playerHP = player.GetComponent<HealthSystem>();
            playerHP.damage(1);
            StartCoroutine(waitColorChange());
            iFrame = false;
        }
    }

    IEnumerator waitColorChange()
    {
        iFrame = true;
        spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds((float)0.2);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    public int getHP()
    {
        return hp;
    }

    public void damage(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
    }

    public void heal(int heal)
    {
        hp += heal;
        if (hp > 4)
        {
            hp = 4;
        }
    }
}

