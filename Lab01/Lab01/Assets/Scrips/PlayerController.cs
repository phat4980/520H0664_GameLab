using UnityEngine;
using System . Collections ;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    
    

    void Start()
    {
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter ( Collider other )
    {
        if( other.gameObject.tag=="PickUp" )
        {
            other.gameObject.SetActive( false);
            count++;
            SetCountText();
        }
    }

   void SetCountText()
	{
		scoreText.text = "Count: " + count.ToString();

		if (count >= 7) 
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
		}
	}
}