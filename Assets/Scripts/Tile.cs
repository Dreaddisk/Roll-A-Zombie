using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	#region Variables
	public GameManager gameManager;
	public AudioClip hit;
	AudioSource source;
	#endregion Variables

	#region Functions
	private void Start()
	{
		source = GetComponent<AudioSource>();

	}
	#endregion Functions

	#region Methods
	void OnTriggerEnter(Collider other)
	{
		gameManager.AddPoint();
		source.PlayOneShot(hit);
	}
	#endregion Methods

} // Main Class
