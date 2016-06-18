﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private bool isShaking = false;
	private float baseX, baseY, baseZ;
	private float intensity;
	private int shakes = 0;

	// Use this for initialization
	void Start () {

		baseX = transform.position.x;
		baseY = transform.position.y;
		baseZ = transform.position.z;

		intensity = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (isShaking) {

			float randomShakeX = Random.Range(-intensity, intensity);
			float randomShakeY = Random.Range(-intensity, intensity);
			float randomShakeZ = Random.Range(0, intensity * 2);

			transform.position = new Vector3(baseX + randomShakeX, baseY + randomShakeY, baseZ + randomShakeZ);

			shakes--;

			if (shakes <= 0) {

				isShaking = false;
				transform.position = new Vector3(baseX, 1.83333333f, baseZ);
			}
		}
	}

	public void ShortShake(float in_intensity) {

		isShaking = true;
		shakes = 10;
		intensity = in_intensity;
	}

	public void LongShake(float in_intensity) {

		isShaking = true;
		shakes = 100;
		intensity = in_intensity;
	}
}
