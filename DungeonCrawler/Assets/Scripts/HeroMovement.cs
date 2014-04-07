﻿using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

	class HeroInfo{
		public float heroPosX;
		public float heroPosY;
		public float heroSpeed = 5.0f;
		public float turnSpeed;
		public float targetAngle = 0.0f;
	}

	public int heroLevel = 1;

	public void TargetAngle(float speed, float target){
		float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z,target,speed*Time.deltaTime);
		transform.eulerAngles = new Vector3(0,0,angle);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		HeroInfo hero = new HeroInfo();
		hero.heroPosX = transform.position.x;
		hero.heroPosY = transform.position.y;
		hero.turnSpeed = 200.0f;
	
		//Velocity vectors to give movement to the hero
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.velocity = new Vector3(0,hero.heroSpeed,0);
			TargetAngle(hero.turnSpeed,90);
			if (Input.GetKey (KeyCode.RightArrow)) {
				rigidbody.velocity = new Vector3(hero.heroSpeed,hero.heroSpeed,0);
				TargetAngle(hero.turnSpeed,45);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				rigidbody.velocity = new Vector3(-hero.heroSpeed,hero.heroSpeed,0);
				TargetAngle(hero.turnSpeed,135);
			}
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			rigidbody.velocity = new Vector3(0,-hero.heroSpeed,0);
			TargetAngle(hero.turnSpeed,270);
			if (Input.GetKey(KeyCode.RightArrow)){
				rigidbody.velocity = new Vector3(hero.heroSpeed,-hero.heroSpeed,0);
				TargetAngle(hero.turnSpeed,315);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)){
				TargetAngle(hero.turnSpeed,225);
				rigidbody.velocity = new Vector3(-hero.heroSpeed,-hero.heroSpeed,0);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			rigidbody.velocity = new Vector3(hero.heroSpeed,0,0);
			TargetAngle(hero.turnSpeed,0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.velocity = new Vector3(-hero.heroSpeed,0,0);
			TargetAngle(hero.turnSpeed,180);
		}
		else{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}
