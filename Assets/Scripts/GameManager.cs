using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region Variables
	private int selectedZombiePosition = 0;
	private int score = 0;

	public Text scoreText;
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defaultSize;
	public float impulseForce = 5.0f;
	#endregion Variables

	#region Functions
	private void Start()
	{
		SelectZombie(selectedZombie);
		scoreText.text = "Score: " + score;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			GetZombieRight();
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GetZombieLeft();
		}

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			PushUp();
		}
	}
	#endregion Functions

	#region Methods

	void SelectZombie(GameObject newZombie)
	{
		selectedZombie.transform.localScale = defaultSize;
		selectedZombie = newZombie;
		newZombie.transform.localScale = selectedSize;
	}

	// Move zombie to the left
	void GetZombieLeft()
	{
		if (selectedZombiePosition == 0)
		{
			selectedZombiePosition = 3;
			SelectZombie(zombies[3]);
		}
		else
		{
			selectedZombiePosition = selectedZombiePosition - 1;
			GameObject newZombie = zombies[selectedZombiePosition];
			SelectZombie(newZombie);
		}
	}

	// Move zombie to the right
	void GetZombieRight()
	{
		if (selectedZombiePosition == 3)
		{
			selectedZombiePosition = 0;
			SelectZombie(zombies[0]);
		}
		else
		{
			selectedZombiePosition = selectedZombiePosition + 1;
			SelectZombie(zombies[selectedZombiePosition]);
		}
	}

	void PushUp()
	{
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
		rb.AddForce(0, 0, impulseForce, ForceMode.Impulse);

	}

	public void AddPoint()
	{
		score = score + 1;
		scoreText.text = "Score: " + score;
	}
	#endregion Methods

} // Main Class
