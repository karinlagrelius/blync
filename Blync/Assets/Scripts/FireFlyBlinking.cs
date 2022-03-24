using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyBlinking : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]

    const float period = 8f;
    const float onTime = 0.5f;
    float nextTime;

    [SerializeField]
    public bool lit;

    public Material[] mats;
    Material flylit;
    Material flyunlit;

    [SerializeField]
    public bool canNudge;

    void Start() {
        nextTime = Time.time + Random.Range(0f, period);
        lit = false;
        flyunlit = mats[0];
        flylit = mats[1];
        GetComponent<Renderer>().material = flyunlit;
    }

    // Move timer closer to neighbors blinking pattern.
    public void Nudge() {
        if(!lit){
          nextTime -= (nextTime - Time.time)/2; // Tortoise catches up to the rabbit...
          // randomness? todo
        }
    }

    // Update is called once per frame
    void Update() {
      if(Time.time >= nextTime){
        if(!lit){
          canNudge = true;
          lit = true;
          GetComponent<Renderer>().material = mats[1];
          nextTime += onTime;
        } else {
          canNudge = false;
          lit = false;
          GetComponent<Renderer>().material = mats[0];
          nextTime += period-1;
        }
      }
    }
}
