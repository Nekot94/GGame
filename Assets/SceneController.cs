﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;

    private GameObject _enemy;

	void Start () {
		
	}
	
	
	void Update () {
        if (_enemy == null) {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 2, 3);
            float angle = Random.Range(0, 360);
            transform.Rotate(0, angle, 0);
        }
	}
}
