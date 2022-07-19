using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI playerLives;
	public GameObject winTextObject;
	public GameObject loseTextObject;
	public GameObject door;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count, score, lives;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;
		score = 0;
		lives = 3;
		SetCountText();
		SetScoreText();
		SetPlayerLives();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.SetActive(false);
		loseTextObject.SetActive(false);
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;
			score = score + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
			SetScoreText();
		}
		else if(other.gameObject.CompareTag("Enemy"))
        {
			other.gameObject.SetActive(false);
			score = score - 1;
			if (score <= 0)
				score = 0;
			SetScoreText();
			lives = lives - 1;
			SetPlayerLives();
			
        }
	}

	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if(count==12)
        {
			Destroy(door);
        }
		if (count >= 24)
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
		}
	}

	void SetScoreText()
    {
		scoreText.text = "Score: " + score.ToString();
    }

	void SetPlayerLives()
    {
		playerLives.text = "Lives: " + lives.ToString();
		if(lives<=0)
        {
			loseTextObject.SetActive(true);
			Destroy(gameObject);
		}
    }
}