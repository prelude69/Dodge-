using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    // public float rotationSpeed = 60f;
    // public float rotateDegree = 0f;
    // public const float Deg2Rad = Mathf.PI / 160f;
    // public float radius;
    // public float xPos;
    // public float zPos;
    // private Transform point;
    // void Start(){
    //     point = GameObject.FindGameObjectWithTag("point").transform;
    // }
    // void Update() {
    //     Vector3 pos = gameObject.transform.position;
    //     rotateDegree += rotationSpeed * Time.deltaTime;
    //     radius = (float)Mathf.Sqrt(pos.x * pos.x + pos.z * pos.z);
    //     xPos = radius * Mathf.Cos(Deg2Rad * rotateDegree);
    //     zPos = radius * Mathf.Sin(Deg2Rad * rotateDegree);
    //     transform.position = new Vector3(xPos, pos.y, zPos);
    //     transform.LookAt(point);
    //     //transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    //}

    public float rotationSpeed = 60f;
    void Update(){
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}