using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyBlinking : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]

    const float interval = 1;
    const float period = 8f;
    float nextTime;

    [SerializeField]
    public bool lit;

    public Material[] mats;
    Material flylit;
    Material flyunlit;

    [SerializeField]
    float timer;

    void Start() {
        float seed = Random.Range(0f, period);
        timer = seed;
        lit = false;
        flyunlit = mats[0];
        flylit = mats[1];
        GetComponent<Renderer>().material = flyunlit;
        nextTime = 1 - (seed % period); // Remainder of a second
        //prevTime = Time.time + Random.Range(0f, period);
        //nextTime = prevTime + period;
    }

    // When the fly spawns, set timer to zero. Set

    // Move timer closer to go
    public void Nudge() {
        Debug.Log("Got nudged!");
        timer += (period - timer)/2; // Tortoise catches up to the rabbit...
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