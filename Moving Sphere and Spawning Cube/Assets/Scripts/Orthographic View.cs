using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicView : MonoBehaviour
{
    //public GameObject gameObject;
    //public bool ortho;

    // Start is called before the first frame update
    void Start()
    {
        //ortho = Camera.orthographic;
        //ortho = true;
        Camera.main.orthographic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
