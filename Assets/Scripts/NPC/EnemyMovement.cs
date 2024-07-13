using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{

	[SerializeField] private AnimateSpider _animateSpider;
	[SerializeField] private float _changeDirectionSpeed;

	private float _noiseOffset;
	
	private void Start()
	{
		_noiseOffset = Random.Range(0F, 100F);
	}

	private void Update()
	{
		var noise = Mathf.PerlinNoise1D((Time.time + _noiseOffset) * _changeDirectionSpeed);
		var dir = new Vector3(-Mathf.Cos(noise * 2 * Mathf.PI), 0F, -Mathf.Sin(noise * 2 * Mathf.PI));

		_animateSpider.SetTargetDirection(dir);
	}
}
