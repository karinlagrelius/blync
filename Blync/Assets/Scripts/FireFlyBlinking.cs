using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyBlinking : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]

    const int interval = 1;
    const int period = 8;
    float nextTime;

    public Material[] mats;
    Material flylit;
    Material flyunlit;
    int timer;

    void Start() {
        flyunlit = mats[0];
        flylit = mats[1];
        GetComponent<Renderer>().material = flyunlit;
        nextTime = 0;
        timer = Random.Range(0, period);
    }

    // Update is called once per frame
    void Update() {
        if(Time.time >= nextTime) {
            timer++;
            timer = timer % period;
            nextTime += interval;
        }
        if(timer == 0) {
            GetComponent<Renderer>().material = mats[1];

        } else if(timer == 1) {
            GetComponent<Renderer>().material = mats[0];
        }
    }
}
