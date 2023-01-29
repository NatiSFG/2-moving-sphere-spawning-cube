using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    private bool isMoving;
    private Vector3 originalPosition, targetPosition;

    //time it takes for player to move from originalPosition to targetPosition. In seconds (so 1/5th of a second)
    private float timeToMove = 0.2f;
    
    void Start() {
        
    }

    void Update() {
 
        if (Input.GetKey(KeyCode.W) && !isMoving) StartCoroutine(MovePlayer(Vector3.forward));
        if (Input.GetKey(KeyCode.A) && !isMoving) StartCoroutine(MovePlayer(Vector3.left));
        if (Input.GetKey(KeyCode.S) && !isMoving) StartCoroutine(MovePlayer(Vector3.back));
        if (Input.GetKey(KeyCode.D) && !isMoving) StartCoroutine(MovePlayer(Vector3.right));
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float elapsedTime = 0;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        while(elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime/timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }
}
