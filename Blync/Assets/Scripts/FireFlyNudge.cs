using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyNudge : MonoBehaviour {
    private List<GameObject> neighbors = new List<GameObject>();

    [SerializeField]
    int numberOfNeighbors;
    float radius;
    // Start is called before the first frame update
    void Start() {
        //neighbors = new List<GameObject>();
        numberOfNeighbors = neighbors.Count;
    }

    void OnTriggerEnter(Collider other) {
        // Kolla label, se om det är en firefly, isf lägg till i neighbors och kolla i update om de blinkar
        if (other.gameObject.tag == "Firefly") {
            neighbors.Add(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
      // Problem with this: loop over all neighbours every frame, and THEN check if its even relevant.
      // fix: check if lit first.
      if(gameObject.GetComponent<FireFlyBlinking>().lit && gameObject.GetComponent<FireFlyBlinking>().canNudge) { // Shouldn't check every single frame.
        gameObject.GetComponent<FireFlyBlinking>().canNudge = false; // to not nudge every neighbour every frame that this one is lit.
        for (int i = neighbors.Count - 1; i > 0; i--) {
            if (Vector3.Distance(gameObject.transform.position, neighbors[i].transform.position) > 10/*gameObject.GetComponent<SphereCollider>().radius*/) {
              neighbors.RemoveAt(i); // could be an expensive operation...
              // Debug.Log("out of range, removed");
            } else {
              neighbors[i].GetComponent<FireFlyBlinking>().Nudge();
              // gameObject.GetComponent<FireFlyBlinking>().Nudge(); It was nudging itself...
              // neighbors.RemoveAt(i);
              // Debug.Log("Nudged, removed");
            }
          }
        }
      numberOfNeighbors = neighbors.Count;
      // prints slow down the execution A LOT!
      // Debug.Log("Neighbors: " + numberOfNeighbors);
    }
}
