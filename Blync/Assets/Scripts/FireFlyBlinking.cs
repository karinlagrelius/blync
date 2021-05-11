using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyBlinking : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]

    const float interval = 1;
    const float period = 8;
    float nextTime;

    [SerializeField]
    public bool lit;

    public Material[] mats;
    Material flylit;
    Material flyunlit;

    [SerializeField]
    float timer;

    void Start() {
        lit = false;
        flyunlit = mats[0];
        flylit = mats[1];
        GetComponent<Renderer>().material = flyunlit;
        nextTime = 0;
        timer = Random.Range(0, period);
    }

    // Move timer closer to go
    public void Nudge() {
        timer += (period - timer)/4; // Tortoise catches up to the rabbit...
    }

    // Update is called once per frame
    void Update() {
        if(Time.time >= nextTime) {
            timer++;
            timer = timer % period;
            nextTime += interval;
        }
        if(timer <= 1) {
            GetComponent<Renderer>().material = mats[1];
            lit = true;

        } else {
            GetComponent<Renderer>().material = mats[0];
            lit = false;
        }
    }
}