using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Life;

    public int life;
    public int score;
    public int count = 0;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void lifeDown()
    {
        life--;
        if (life > -1)
        {
            GameObject UILife = Life.transform.GetChild(life).gameObject;
            Destroy(UILife);
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }


    public int getCount()
    {
        if (count % 10 == 0) return 10;
        return count % 10;
    }
    public void scoreCount()
    {
        switch (count % 10)
        {
            case 1: score += 10; break;
            case 2: score += 20; break;
            case 3: score += 30; break;
            case 4: score += 50; break;
            case 5: score += 100; break;
            case 6: score += 200; break;
            case 7: score += 300; break;
            case 8: score += 500; break;
            case 9: score += 1000; break;
            case 0: score += 2000; break;

        }
    }
}
