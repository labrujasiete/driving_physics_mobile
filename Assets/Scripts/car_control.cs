using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_control : MonoBehaviour
{

    public WheelCollider front_driverCol, front_passCol;
    public WheelCollider back_driverCol, back_passCol;

    public Transform frontDriver, frontPass;
    public Transform backDriver, backPass;



    public Joystick TouchAccelerate;
    public Joystick TouchSteer;

    public float _steerAngle = 25.0f;
    public float _engineForce = 1500f;
    public float steerAngl;

    
    float h,v;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Inputs();
        getTouch();
        Drive();
        SteerCar();

        UpdateWheelPos(front_driverCol, frontDriver);
        UpdateWheelPos(front_passCol, frontPass);
        UpdateWheelPos(back_driverCol, backDriver);
        UpdateWheelPos(back_passCol, backPass);
    }


    void Inputs(){
        h = TouchSteer.Horizontal;
        v = TouchAccelerate.Vertical;
    }

    void getTouch(){

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            //Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }


        // if(Input.touchCount > 0){
        //     Touch touch = Input.GetTouch(0);
        //     Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //     touchPosition.z = 0f;
        //     transform.position = touchPosition;
        // }
    }

    void Drive(){
        back_driverCol.motorTorque = v * _engineForce;
        back_passCol.motorTorque = v * _engineForce;
    }

    void SteerCar(){
        steerAngl = _steerAngle * h;
        front_driverCol.steerAngle = steerAngl;
        front_passCol.steerAngle = steerAngl;
    }

    void UpdateWheelPos(WheelCollider col, Transform t){
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        col.GetWorldPose(out pos, out rot);
        t.position = pos;
        t.rotation = rot;

    }



}
