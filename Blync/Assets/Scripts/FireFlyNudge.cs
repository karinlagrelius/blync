using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyNudge : MonoBehaviour {
    private List<GameObject> neighbors = new List<GameObject>();

    [SerializeField]
    int numberOfNeighbors;
    // Start is called before the first frame update
    void Start() {
        //neighbors = new List<GameObject>();
        numberOfNeighbors = neighbors.Count;
        //radius = gameObject.getchild blabla hämta bubblan
    }

    void OnTriggerEnter(Collider other) {
        // Kolla label, se om det är en firefly, isf lägg till i neighbors och kolla i update om de blinkar
        if (other.gameObject.tag == "Firefly") {
            neighbors.Add(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = neighbors.Count - 1; i > 0; i--) {
            if(gameObject.GetComponent<FireFlyBlinking>().lit) {  // Shouldn't check every single frame
                gameObject.GetComponent<FireFlyBlinking>().Nudge();
                neighbors.RemoveAt(i);
                //Debug.Log("Nudged, removed");
            } else if (Vector3.Distance(gameObject.transform.position, neighbors[i].transform.position) > 3/*gameObject.GetComponent<SphereCollider>().radius*/) {
                neighbors.RemoveAt(i);
                //Debug.Log("out of range, removed");
            }
        }
        numberOfNeighbors = neighbors.Count;
    }
}