using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyMovement : MonoBehaviour {
    // Update coordinates
    Vector3 pos;
    Vector3 dir;
    float speed = 0.05f;

    void Move() {
        Vector3 temp = Vector3.Lerp(pos, pos +  new Vector3((Random.value-0.5f)*speed, (Random.value-0.5f)*speed, (Random.value-0.5f)*speed), Time.time);
        pos = temp;
        transform.position = pos;
    }
    // Start is called before the first frame update
    void Start() {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }
}
