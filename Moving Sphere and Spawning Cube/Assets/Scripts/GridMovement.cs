using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private float forwardBoundary = 3f;
    [SerializeField] private float leftBoundary = -5f;
    [SerializeField] private float backBoundary = -5f;
    [SerializeField] private float rightBoundary = 3f;

    private bool isMoving;

    //time it takes for player to move from originalPosition to targetPosition. In seconds (so 1/5th of a second)
    private float timeToMove = 0.2f;
    
    void Update() {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) StartMove(Vector3.forward);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) StartMove(Vector3.left);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) StartMove(Vector3.back);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) StartMove(Vector3.right);
        PlayerBoundaries();
    }

    private bool StartMove(Vector3 direction) {
        if (isMoving) return false;
        StartCoroutine(MovePlayer(direction));
        return true;
    }

    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float elapsedTime = 0;

        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + direction;

        while(elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime/timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }

    void PlayerBoundaries() {
        if(transform.position.x > rightBoundary) {
            transform.position = new Vector3(rightBoundary, 0, transform.position.z);
            return;
        } else if(transform.position.x < leftBoundary) {
            transform.position = new Vector3(leftBoundary, 0, transform.position.z);
            return;
        }
        if(transform.position.z > forwardBoundary) {
            transform.position = new Vector3(transform.position.x, 0, forwardBoundary);
            return;
        } else if(transform.position.z < backBoundary) {
            transform.position = new Vector3(transform.position.x, 0, backBoundary);
            return;
        }
    }
}
