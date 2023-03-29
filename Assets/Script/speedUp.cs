using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUp : MonoBehaviour, IItem
{
    public float rotationSpeed = 60f;

    private void Start()
    {
        transform.Rotate(45f, 0f, 0f);
    }
    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f,Space.World);
    }
    public void Use()
    {
        OVRPlayerController speed = GameObject.Find("player").GetComponent<OVRPlayerController>();
        speed.Acceleration = 0.2f;
        Invoke("speedDown", 5f);
    }

    private void speedDown(){
        OVRPlayerController speed = GameObject.Find("player").GetComponent<OVRPlayerController>();
        speed.Acceleration = 0.1f;
    }
}
