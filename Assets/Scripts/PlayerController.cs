using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed = 500;
	public Rigidbody rb;
	private int health = 5;
	
	private int score;

	void Update () {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("w"))
			rb.AddForce(0, 0, speed * Time.deltaTime);
		if (Input.GetKey("s"))
			rb.AddForce(0, 0, -(speed * Time.deltaTime));
		if (Input.GetKey("a"))
			rb.AddForce(-(speed * Time.deltaTime), 0 , 0);
		if (Input.GetKey("d"))
			rb.AddForce(speed * Time.deltaTime, 0 ,0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score += 1;
			Destroy(other.gameObject);
			Debug.Log("Score: " + score);
		}

		if (other.tag == "Trap")
		{
			health -= 1;
			Debug.Log("Health: " + health);
		}

		if (other.tag == "Goal")
		{
			Debug.Log("You win!");
		}
	}
}
