using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int lives;
	public static int breakableCount;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int hitCount;
	private bool isBreakable;

	/* 
	 * Initializes a brick, verifies breakability of a brick, generates lives count
	 */
	void Start () {
		
		isBreakable =(this.tag == "Breakable");
		//Track breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		hitCount = 0;
		lives = 3;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	
	}
	
	/* 
	 * Checks if there is a collision between the ball and a brick
	 */
	void OnCollisionEnter2D(Collision2D collision) {
		
		if (isBreakable) { //checks if the (this) block hit can be broken
			handleHits();
		}
	} 
	
	/* 
	 * Handles situations where a brick is hit by a ball
	 * 
	 * Modifies: updates the hit count of a ball, and removes when the
	 * hit count reaches the brick's max count
	 */
	void handleHits() {
		hitCount++;
		int maxHitCount = hitSprites.Length + 1;
		//destory brick if max hit count is reached
		//decrease breakable count
		if (hitCount >= maxHitCount) {
			breakableCount--;
			//AudioSource.PlayClipAtPoint(crack, transform.position);
			puffSmoke();
			levelManager.brickDestroyed();
			Destroy(gameObject);
		} else { //loads next stage of decay based on number of its brick as taken
			loadSprites();
		}
	}
	
	/*
	 * Makes a smoke puff for the given brick at the bricks location with that color
	 */
	void puffSmoke() {
		//instantiate smoke at the location of the brick at a default rotation (angle)
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		
	}
	
	/* 
	 * Loads the next available sprite from a sprite list. Used in updating the look of 
	 * a multi-hit block that has been "damaged". Called by handleHits()
	 * 
	 * Modifies: Updates the sprite of a damaged brick
	 * 
	 * Logs: Error if no sprite found
	 */
	void loadSprites(){
		int idx =  hitCount - 1;
		
		//verify there is a sprite at the next index
		//loads the next sprite if there is a sprite there
		if(hitSprites[idx]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites[idx];
		} else{
			Debug.LogError("No brick sprite found");
		}
	}
	

}





