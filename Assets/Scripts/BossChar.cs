using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossChar : MonoBehaviour
{

    public int hp;
    GameObject enemy;
    GameObject player;
    SpriteRenderer spriteRenderer;
    bool BossAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        enemy = GameObject.Find("EnemyAI");
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we kill the boss, hide it from scene
        if (hp == 0)
        {
            PlayerScore.increaseScore(100);
            enemy.SetActive(false);
            BossAlive = false;
        }

        if (Input.GetKeyUp("f"))
        {
            
            float distanceFromEnemy = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (distanceFromEnemy < 10)
            {
                PlayerScore.increaseScore(10);
                BossChar enemyObj = enemy.GetComponent<BossChar>();
                enemyObj.damage(1);
            }
        }

        if (!BossAlive)
        {
            Scene thisScene = SceneManager.GetActiveScene();
            if (thisScene.name == "Tutorial")
            {
                SceneManager.LoadScene("Kitchen_Level");
            }
            if(thisScene.name == "Kitchen_Level")
            {
                SceneManager.LoadScene("LivingRoom_level");
            }
            if (thisScene.name == "LivingRoom_level")
            {
                SceneManager.LoadScene("Dining_level");
            }
            if (thisScene.name == "Dining_level")
            {
                SceneManager.LoadScene("End_Game"); //load endgame level UI
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
