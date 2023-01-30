using UnityEngine;

public class ExampleTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name + " entered the trigger!");
    }
}
