using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    
    private int numPickUp = 7;
    private LineRenderer lineRenderer;
    private GameObject player;
    // private float minDistance = 0;
    // private GameObject end;
    // private GameObject previousEnd = null;
    private enum State { 
        Normal,
        Distance,
        Vision,
    }
    private State currentState;
    public int count = 0;
    public Color previousColor;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPos;
    public TextMeshProUGUI playerVelocity;
    public TextMeshProUGUI Distance;
    public List<GameObject> pickUps;
    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        
    }

    public void SetCountText()
    {
        scoreText.text = "Score:" + count.ToString();
        if (count >= numPickUp)
        {
            winText.text = "You Win!";
        }
    }
}
