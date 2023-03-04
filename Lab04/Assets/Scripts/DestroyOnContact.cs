using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int score;

    void Start()
    {
        GameObject Controller = GameObject.FindWithTag("GameController");
        if(Controller != null)
        {
            gameController = Controller.GetComponent<GameController>();
        }
        if(Controller == null)
        {
            Debug.Log("GameController not found");
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Boundary") 
            return;
        Instantiate(explosion, transform.position, transform.rotation); 
        if(other.tag=="Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOverD();
        }
        gameController.addScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
