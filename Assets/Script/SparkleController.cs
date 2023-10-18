using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleController : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        //transform.Rotate(new Vector3(0, 0, 25 * Time.deltaTime));
    }
}
