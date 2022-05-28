using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour {
    public Transform[] Waypoints;
    private float _movementSpeed = 50f;
    private int _wayPointIndex = 0;

    private void Start() {
        transform.position = Waypoints[_wayPointIndex].transform.position;
    }

    private void Update() {
        Move();
    }

    private void Move() {
        //if (_wayPointIndex <= Waypoints.Length - 1) {
            transform.position = Vector2.MoveTowards(transform.position,
                Waypoints[_wayPointIndex].transform.position,
                _movementSpeed * Time.deltaTime);
        //}

        if (transform.position == Waypoints[_wayPointIndex].transform.position) {
            _wayPointIndex++;
            if (_wayPointIndex > Waypoints.Length-1) _wayPointIndex = 0;
        }

    }
}
