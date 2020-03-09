using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour {

    public SpriteRenderer screen1;
    public SpriteRenderer screen2;
    public GameObject player;

    public Transform obstacle;
    public GameObject[] obstacles;

    public List<Sprite> backgrounds;

    int chanceToGetObstacle = 8;

    void Start () {
        ChooseBackground(1, 0);
        ChooseBackground(2, 1);
	}

    public void ChooseBackground(int screenID, int id = -1)
    {
        SpriteRenderer screen;
        if (screenID == 1)
        {
            screen = screen1;
        } else
        {
            screen = screen2;
        }

        if (id == -1)
        {
            id = (int)Mathf.Floor(Random.Range(0.0f, 6.0f));
        }

        screen.sprite = backgrounds[id];
    }

    public void SwapScreens()
    {
        Vector3 temp = screen2.transform.position;
        screen2.transform.position = screen1.transform.position;
        screen1.transform.position = temp;
        player.transform.Translate(Vector2.left * Mathf.Abs(screen2.transform.position.x - screen1.transform.position.x) * -1);

        // GenerateObstacles();
    }

    public void GenerateObstacles()
    {
        // I initially wanted to generate obstacles for the player to avoid, but removed them after considering the game difficulty was already high enough
        if (Mathf.Floor(Random.Range(0.0f, 10.0f)) > 2)
        {
            
            Transform obs = Instantiate(obstacle, new Vector3(Random.Range(0.0f, 0.2f), -Random.Range(0.0f, 3.5f), 0), Quaternion.identity);
            obs.transform.position = GameObject.Find("ObstacleInitialPos").transform.position;
            obs.transform.position = new Vector3(obs.transform.position.x + Random.Range(0.0f, 0.2f), obs.transform.position.y - Random.Range(0.0f, 3.5f), obs.transform.position.z);

            if (Mathf.Floor(Random.Range(0.0f, 10.0f)) > 5)
            {

                Transform obs2 = Instantiate(obstacle, new Vector3(Random.Range(0.0f, 0.2f), -Random.Range(0.0f, 3.5f), 0), Quaternion.identity);
                obs2.transform.position = GameObject.Find("ObstacleInitialPos").transform.position;
                obs2.transform.position = new Vector3(obs.transform.position.x + Random.Range(0.0f, 0.2f), obs.transform.position.y - Random.Range(0.0f, 3.5f), obs.transform.position.z);
            }
        }
        
    }
}
