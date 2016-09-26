﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Rigidbody2D rb;
	private float patrolTime = 1;
	private float force = 200;
	private float patrolTimer;
	Vector2 direction;

	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
		direction = Vector2.right * (Random.Range (0f, 1f) > 0.5 ? 1 : -1);
	}

	private void Update () {
		Patrol ();
	}

	private void Patrol () {
		patrolTimer += Time.deltaTime;

		if (patrolTimer >= patrolTime) {
			rb.velocity = Vector2.zero;
			patrolTimer = 0;
			direction *= -1;
		}

		rb.AddForce (direction * force * Time.deltaTime);
	}
}