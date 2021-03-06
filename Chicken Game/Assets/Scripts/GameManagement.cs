﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

	public int pointsToWin;

	public static int score;
	public static int health;
	public static int ammo;

	public Text healthDisplay;
	public Text scoreDisplay;
	public Text ammoDisplay;
	public Text conditionDisplay;
	public Text reloadDisplay;

	void Awake () {
		score = 0;
		health = 100;
		ammo = 32;
		conditionDisplay.text = "";
	}

	void Update(){
		scoreDisplay.text = "Score: " + score;
		healthDisplay.text = "Health: " + health;
		ammoDisplay.text = "Ammo: " + ammo + "/" + "32";

		if(score<0){
			score = 0;
		}
		if(ammo<0){
			ammo = 32;
		}
		if(health<=0){
			health = 100;
			GameOver();
		}

		if(score >= pointsToWin){
			GameWin();
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
		}
        
		if (Input.GetKeyDown(KeyCode.R))
        {
            print("Reload");
            GameManagement.ammo = 32;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			reloadDisplay.enabled = false;
        }


	}

	public static void AddPoints(int pointsToAdd){
		score += pointsToAdd;
	}
	public static void DecreaseAmmo(int ammoRemove){
		ammo -= ammoRemove;
	}
	public static void HealthModifier(int hp){
		health += hp;
	}

	void GameOver(){
		Debug.Log("Game Over");
		conditionDisplay.text = "Game Over! \n Press Esc for Menu.";
		Time.timeScale = 0.0f;
	}

	void GameWin(){
		Debug.Log("Victory");
		conditionDisplay.text = "You Win! \n Press Esc for Menu.";
		Time.timeScale = 0.0f;
	}
}
