using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulation : MonoBehaviour
{
    private Camera cam;
    private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
       cam = Camera.main;
       cam.orthographicSize = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal")*speed;
        float yMove = Input.GetAxis("Vertical")*speed;
        cam.transform.position = new Vector3 (transform.position.x +xMove, transform.position.y +yMove, -1000f);

        float scroll = Input.mouseScrollDelta.y;
        if(cam.orthographicSize-scroll >=5f && cam.orthographicSize-scroll <=50f){
            cam.orthographicSize -= scroll;
        }
        else{
            //do nothing
        }
        
    }
}
