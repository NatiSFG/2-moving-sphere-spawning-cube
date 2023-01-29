using UnityEngine;

public class SpawnObject : MonoBehaviour {
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject player;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 4), 0, Random.Range(-5, 4));
            if (spawnPosition != player.transform.position) {
                GameObject.Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }

        }
    }
}
