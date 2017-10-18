using UnityEngine;

using System.Collections;

public class Ball : MonoBehaviour {


	private Paddle paddle;
	private bool hasStarted;
	private Vector3 paddleToBallVector;	
	private Lives lives;

	// Use this for initialization
	void Start () {

		initBallLoc();
		lives = GameObject.FindObjectOfType<Lives>();
	}
	
	public void initBallLoc() {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector =  this.transform.position - paddle.transform.position;
	}
	
	/*
	 * Update is called once per frame
	 */
	void Update () {
		if (!hasStarted) {
			//Keep ball locked to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//Launch ball on mouse press
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launching ball");
				float xVel = Random.Range(-2f, 2f);
				this.rigidbody2D.velocity = new Vector2(xVel, 10f);
				hasStarted = true;
			}
		}
	}
	
	/* 
	 * Checks if there is a collision between the ball and another game object
	 * 
	 * Modifies: Updates the speed and direction of the ball based off of the interaction with 
	 * said other object.
	 */
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweakVel = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.2f));
		
		if (hasStarted) {
			audio.Play() ;
			rigidbody2D.velocity += tweakVel;
		}
	}
	/* 
	 *  Restarts the ball if the ball triggers the lose collider. 
	 *
	 * Modifies: Gives the ball an upward velocity of 10 from current paddle location.
	 * Gives a random x vel [-.2, .2]. Decrements lives count.
	 */
	public void restart() {
		float xVel = Random.Range(-2f, 2f);
		this.rigidbody2D.velocity = new Vector2(xVel, 10f);
		this.transform.position = paddle.transform.position + new Vector3(0f, 1f, 0f);
		lives.decrement();
		
	}
	
}
