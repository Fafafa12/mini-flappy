using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIrdScript : MonoBehaviour
{
	public Rigidbody2D myRigidbody;
	public float jumpForce;
	public LogicScript logic;
	public bool isDead = false;
	private Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isDead)
			return;
		if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isDead)
			myRigidbody.velocity = Vector2.up * jumpForce;
		// game over when bird is out of screen
		if (transform.position.y > 16 || transform.position.y < -15)
		{
			logic.gameOver();
			isDead = true;
		}
		if (rb.velocity.y < 0)
		{
			float angle = Mathf.Lerp(0, -90, -rb.velocity.y / 50); // Adjust the divisor for desired rotation speed
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 45, rb.velocity.y / 40)); // Reset rotation when not falling
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		logic.gameOver();
		isDead = true;
	}
}
