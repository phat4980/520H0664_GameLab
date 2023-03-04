using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;

    public float StartWait;
    public float cloneWait;
    public float waveWait;    

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI winText;

    public bool gameOver, restart;
        
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        scoreText.text="Score: 0";
        restartText.text="";
        winText.text="";

        StartCoroutine(Waves());
    }

    [System.Obsolete]
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && restart)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    // Update is called once per frame
    IEnumerator Waves() 
    {
        while(true)
        {
            yield return new WaitForSeconds(StartWait);
            for(int i = 0; i < count; i++)
            {
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            yield return new WaitForSeconds(waveWait);
            
            if(gameOver == true)
            {
                restart = true;
                restartText.text = "Press R key to restart";
                break;
            }
        }
    }

    public void addScore(int sc)
    {
        score += sc;
        scoreText.text = "Score: "+score;

    }

    public void gameOverD()
    {
        winText.text = "Game Over!";
        gameOver = true;
    }
}
