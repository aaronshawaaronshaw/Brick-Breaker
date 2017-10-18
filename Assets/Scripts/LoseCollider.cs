using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManger;
	
	private Paddle paddle;
	private Ball ball;	
	
	
	void Start() {
		levelManger = GameObject.FindObjectOfType<LevelManager>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		ball = GameObject.FindObjectOfType<Ball>();
	}

	/*
	 * Checks for a trigger of the ball entering into the lose collider's zone
	 *
	 * Updates: lives count and calls outOfLives() in case we have no more lives left.
	 */
 	void OnTriggerEnter2D(Collider2D trigger) {
 		Brick.lives--;
 		print (Brick.lives);
 		print (ball.transform.position);
 		print (paddle.transform.position);
 		levelManger.outOfLives();
 		
		ball.restart();
	}


}
