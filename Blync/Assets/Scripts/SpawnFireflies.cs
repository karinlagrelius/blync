using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireflies : MonoBehaviour {
    public GameObject fireflyPrefab;
    private Vector3 screenbounds;
    public int numberOfFlies;
    // Start is called before the first frame update
    void Start() {
      numberOfFlies = 200; // 200 before
      screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

      for (int i = 0; i < numberOfFlies; i++) {
        GameObject fly = Instantiate(fireflyPrefab) as GameObject;
        fly.transform.position = new Vector3((Random.value-0.5f) * screenbounds.x,
                                             (Random.value-0.5f) * screenbounds.y,
                                             (Random.value-0.5f) * screenbounds.z);
      }
    }

    // Update is called once per frame
    void Update() {

    }
}
