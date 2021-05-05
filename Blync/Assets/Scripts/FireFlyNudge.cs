using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyNudge : MonoBehaviour {
    private SphereCollider radius;
    private List<GameObject> neighbors;
    // Start is called before the first frame update
    void Start() {
        neighbors = new List<GameObject>();
        //radius = gameObject.getchild blabla hämta bubblan
    }

    void OnTriggerEnter(Collider other) {
        // Kolla label, se om det är en firefly, isf lägg till i neighbors och kolla i update om de blinkar
    }

    void OnTriggerLeave(Collider other) {
        // Ta bort ur neighbors alt. kolla avståndet i update o gör det där ist
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < neighbors.Count; i++) {
            // Kolla avstånd/nudge
        }
    }
}
