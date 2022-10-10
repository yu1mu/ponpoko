using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    public GameManager gameManager;

    public Text ScoreText;
    public GameObject Score;
    public Sprite[] Scores;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        Score = Instantiate(Score, this.transform);
        Score.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + gameManager.score;
    }

    public void activeScore(int num, Transform score)
    {
        Score.transform.GetComponent<SpriteRenderer>().sprite = Scores[num-1];
        Score.transform.position = score.position;
        Score.SetActive(true);
        Invoke("scoreControl", 0.5f);
    }

    void scoreControl()
    {
        Score.SetActive(false);
    }
}
