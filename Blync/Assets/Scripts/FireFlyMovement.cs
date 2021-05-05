using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMovement : MonoBehaviour {
    // Update coordinates
    Vector3 pos;
    int timer;
    int interval = 15;
    float changeX;
    float changeY;
    float changeZ;
    float speedX;
    float speedY;
    float speedZ;

    void Move() {
      interval = (int)(10+Random.value*40);
      timer++;
      if(timer % interval == 0) { // only change direction once every interval.
        // Random.value gives a value between 0-1.
        // change the acceleration randomly insted of the speed.
        speedX = (Random.value-0.5f); // -0.5 to make acceleration both negative and positive.
      } else if(timer % interval == 1){
        speedY = (Random.value-0.5f);
      } else if(timer % interval == 2) {
        speedZ = (Random.value-0.5f);
      }
      changeX = (0.15f)*speedX;
      changeY = (0.15f)*speedY;
      changeZ = (0.15f)*speedZ;

      pos = Vector3.Lerp(pos, pos + new Vector3(changeX, changeY, changeZ), Time.time);
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
