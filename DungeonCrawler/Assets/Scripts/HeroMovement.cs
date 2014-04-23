﻿
using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

	float heroPosX;
	float heroPosY;
	float heroSpeed = 5.0f;
	float turnSpeed;
	float targetAngle = 0.0f;

	public int heroLevel = 1;
	public int xp;
	public int xpRequired;
	public float Strength;
	public float Toughness;
	public float Dexterity;
	public float Reflex;
	public float Health;

	void TargetAngle(float speed, float target){
		float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z,target,speed*Time.deltaTime);
		transform.eulerAngles = new Vector3(0,0,angle);
	}

	// Use this for initialization
	void Start () {
		heroLevel = 1;
		xp = 0;
		xpRequired = 100;
		Strength = 30;
		Toughness = 30;
		Dexterity = 30;
		Reflex = 30;
		Health = 30;
	}
	
	// Update is called once per frame
	void Update () {
		if (xp >= xpRequired){
			heroLevel = heroLevel + 1;
			Strength = Strength + 1;
			Toughness = Toughness + 1;
			Dexterity = Dexterity + 1;
			Reflex = Reflex + 1;
			Health = Health + 2;
			xp = xp-xpRequired ;
			xpRequired = 100*heroLevel;
			Debug.Log("Hero Level " + heroLevel);
		}

		heroPosX = transform.position.x;
		heroPosY = transform.position.y;
		turnSpeed = 200.0f;
	
		//Velocity vectors to give movement to the hero
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.velocity = new Vector3(0,heroSpeed,0);
			TargetAngle(turnSpeed,90);
			if (Input.GetKey (KeyCode.RightArrow)) {
				rigidbody.velocity = new Vector3(heroSpeed,heroSpeed,0);
				TargetAngle(turnSpeed,45);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				rigidbody.velocity = new Vector3(-heroSpeed,heroSpeed,0);
				TargetAngle(turnSpeed,135);
			}
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			rigidbody.velocity = new Vector3(0,-heroSpeed,0);
			TargetAngle(turnSpeed,270);
			if (Input.GetKey(KeyCode.RightArrow)){
				rigidbody.velocity = new Vector3(heroSpeed,-heroSpeed,0);
				TargetAngle(turnSpeed,315);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				TargetAngle(turnSpeed,225);
				rigidbody.velocity = new Vector3(-heroSpeed,-heroSpeed,0);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			rigidbody.velocity = new Vector3(heroSpeed,0,0);
			TargetAngle(turnSpeed,0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.velocity = new Vector3(-heroSpeed,0,0);
			TargetAngle(turnSpeed,180);
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}
