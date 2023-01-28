using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float movementSpeed = 5f;
    float inputHorizontal;
    float inputVertical;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(inputHorizontal * movementSpeed * Time.deltaTime,
            0, inputVertical * movementSpeed * Time.deltaTime);

        //output to log the position change
        Debug.Log(transform.position);
    }
}
