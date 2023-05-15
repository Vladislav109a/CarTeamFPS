using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Vector3 centerOfMass;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    public Transform frontRigthWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backRigthWheelTransform;
    public Transform backLeftWheelTransform;

    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    float presentAcceleration = 0f;

    public float wheelsToque = 35f;
    private float presentTurnAngle = 0f;
    private Rigidbody rb;

    private void Start()
    {
        rb.centerOfMass = centerOfMass;
    }
    private void Update()
    {
        
        MoveCar();
        CarSteering();
        ApplyBreaks();
    }
    private void MoveCar()
    {
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;
        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    }
    private void CarSteering()
    {
        presentTurnAngle = wheelsToque * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(frontRightWheelCollider, frontRigthWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backRigthWheelTransform);
    }
    void SteeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }
    public void ApplyBreaks()
    {
        if (Input.GetKey(KeyCode.Space))
            presentBreakForce = breakingForce;
        else
            presentBreakForce = 0f;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;
    }
    //[SerializeField] private int FPS = 144;
    //private void OnValidate()
    //{
    //    Application.targetFrameRate = FPS;
    //}
}
