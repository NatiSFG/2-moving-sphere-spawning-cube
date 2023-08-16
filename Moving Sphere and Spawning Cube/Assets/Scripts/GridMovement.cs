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

    private bool up;
    private bool left;
    private bool back;
    private bool right;

    private float timeLastPressedUp     = 0;
    private float timeLastPressedLeft   = 0;
    private float timeLastPressedBack   = 0;
    private float timeLastPressedRight  = 0;

    //time it takes for player to move from originalPosition to targetPosition. In seconds (so 1/5th of a second)
    private float timeToMove = 0.2f;

    //NOTE: Human reaction time is around 0.13sec (?)
    //NOTE: 1sec divided into 60 equal parts.. is 0.0167sec
    //So we NEED more than just THIS frame and the PREVIOUS frame's information.
    
    void Update() {
        //NOTE: Here, you can grab the PREVIOUS values of up, left, back, and right!
        up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow);
        back = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow);

        float time = Time.time;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            timeLastPressedUp = time;

        if (up) StartMove(Vector3.forward);
        if (left) StartMove(Vector3.left);
        if (back) StartMove(Vector3.back);
        if (right) StartMove(Vector3.right);

        //Ex: Up and right..
        //We want diagonals to happen if we pressed up and right within... 0.4sec (?) ..
        //IF NOT.. if 0.4sec have passed, move in the direction of the 1st key press
        float threshold = 0.4f;
        if (timeLastPressedUp - time >= threshold && timeLastPressedRight - time >= threshold) {

        }
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

        if (ValidateGridPosition(targetPosition) == targetPosition) {
            while (elapsedTime < timeToMove) {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        transform.position = ValidateGridPosition(targetPosition);

        isMoving = false;
    }

    private Vector3 ValidateGridPosition(Vector3 position) {
        if (position.x > rightBoundary) {
            position.x = rightBoundary;
        } else if (position.x < leftBoundary) {
            position.x = leftBoundary;
        } else if (position.z > forwardBoundary) {
            position.z = forwardBoundary;
        } else if (position.z < backBoundary) {
            position.z = backBoundary;
        }
        return position;
    }

    //private bool WithinBoardBoundaries() {
    //    Vector3 spherePosition = transform.position;

    //    if(spherePosition.x > rightBoundary) {
    //        spherePosition = new Vector3(rightBoundary, spherePosition.y, spherePosition.z);
    //    } else if(spherePosition.x < leftBoundary) {
    //        spherePosition = new Vector3(leftBoundary, spherePosition.y, spherePosition.z);
    //    } else if (spherePosition.z > forwardBoundary) {
    //        spherePosition = new Vector3(spherePosition.x, spherePosition.y, forwardBoundary);
    //    } else if (spherePosition.z < backBoundary) {
    //        spherePosition = new Vector3(spherePosition.x, spherePosition.y, backBoundary);
    //    } else return true;
    //    transform.position = spherePosition;
    //}
}
