using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}
	
	/*
	 * Handles quit requests, and terminates game.
	 */
	public void QuitRequest(string name) {
		Debug.Log ("Quit request from " + name);
		Application.Quit ();
	}
	
	/*
	 * Loads next level in the predefined build order.
	 */
	public void loadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	/*
	 * Checks to see if all bricks have been destroyed. Calls loadNextLevel() if true
	 */
	public void brickDestroyed() {
		if (Brick.breakableCount <= 0) {//last brick destroyed)
			loadNextLevel();
			
		}
	}
	
	/*
	 * Checks to see if there are no more remaining lives to play with.
	 */
	public void outOfLives() {
		if (Brick.lives <= 0) {
			LoadLevel("Lose");
			Brick.breakableCount = 0;
			print (Brick.breakableCount);
		}
	}
	
	
}



