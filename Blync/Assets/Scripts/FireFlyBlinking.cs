using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyBlinking : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    bool lit;

    const int interval = 1;
    const int period = 8;
    float nextTime;

    public Material[] mats;
    Material FlyLit; 
    Material FlyUnLit;

    int timer;
    //Random dice;

    void Start() {
        mats = GetComponent<Renderer>().materials;
        mats[0] = FlyUnLit; 
        GetComponent<Renderer>().materials = mats; 

        // mats[0] = Materials.Load("FlyLit", typeOf(Material)) as material; 
        //mats[1] = Materials.Load("FlyUnLit", typeOf(Material)) as material; 
        //gameObject.renderer.material = mats[1];
        nextTime = 0;
        //dice = new Random();
        lit = false;
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
            lit = true;
            mats[0] = FlyLit; 
            GetComponent<Renderer>().materials = mats; 
        } else if(timer == 1) {
            lit = false;
            mats[0] = FlyUnLit; 
            GetComponent<Renderer>().materials = mats; 
        } 
        
    }
}
