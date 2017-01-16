using UnityEngine;
using System.Collections;

public class AngularVelocity
{
    private float X;
    private float Y;
    private float Z;

    public float x { get { return X; } set { X = value; } }
    public float y { get { return Y; } set { Y = value; } }
    public float z { get { return Z; } set { Z = value; } }
}
public class AngularAcceleration: AngularVelocity
{

}

public class Angular {
    static public AngularVelocity getQuaternionVelocity(PlayBandData data, ref Quaternion previousRotation)
    {
        AngularVelocity temp = new AngularVelocity();
        float dif = 0.0f;
        float threshold = 0.01f;
        dif = data.Rotation.x - previousRotation.x;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.x = dif;
        }
        else {
            temp.x = 0;
        }
        previousRotation.x = data.Rotation.x;

        dif = data.Rotation.y - previousRotation.y;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.y = dif;
        }
        else {
            temp.y = 0;
        }
        previousRotation.y = data.Rotation.y;

        dif = data.Rotation.z - previousRotation.z;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.z = dif;
        }
        else {
            temp.z = 0;
        }
        previousRotation.z = data.Rotation.z;

        return temp;
    }

    static public AngularAcceleration getQuaternionAcceleration(AngularVelocity currentAngularVelocity, ref AngularVelocity previousAngularVelocity)
    {
        AngularAcceleration temp = new AngularAcceleration();
        float dif = 0.0f;
        float threshold = 0.10f;
        dif = currentAngularVelocity.x - previousAngularVelocity.x;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.x = dif;
        }
        else {
            temp.x = 0;
        }
        previousAngularVelocity.x = currentAngularVelocity.x;

        dif = currentAngularVelocity.y - previousAngularVelocity.y;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.y = dif;
        }
        else {
            temp.y = 0;
        }
        previousAngularVelocity.y = currentAngularVelocity.y;

        dif = currentAngularVelocity.z - previousAngularVelocity.z;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.z = dif;
        }
        else {
            temp.z = 0;
        }
        previousAngularVelocity.z = currentAngularVelocity.z;

        return temp;
    }

    static public AngularAcceleration getRotationAcceleration(AngularVelocity currentAngularVelocity, ref AngularVelocity previousAngularVelocity)
    {
        AngularAcceleration temp = new AngularAcceleration();
        float dif = 0.0f;
        float threshold = 0.01f;
        dif = currentAngularVelocity.x - previousAngularVelocity.x;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.x = dif;
        }
        else {
            temp.x = 0;
        }
        previousAngularVelocity.x = currentAngularVelocity.x;

        dif = currentAngularVelocity.y - previousAngularVelocity.y;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.y = dif;
        }
        else {
            temp.y = 0;
        }
        previousAngularVelocity.y = currentAngularVelocity.y;

        dif = currentAngularVelocity.z - previousAngularVelocity.z;
        if (Mathf.Abs(dif) > threshold)
        {
            temp.z = dif;
        }
        else {
            temp.z = 0;
        }
        previousAngularVelocity.z = currentAngularVelocity.z;

        return temp;
    }

    static public AngularVelocity getRotationVelocity(PlayBandData data, ref Vector3 previousRotation)
    {
        AngularVelocity temp = new AngularVelocity();
        float dif = 0.0f;
        float threshold = 0.0f;
        dif = data.EulerAngles.x - previousRotation.x;
        /*if (Mathf.Abs(dif) > threshold)
        {
            temp.x = dif;
        }*/
        temp.x = dif;
        previousRotation.x = data.EulerAngles.x;

        dif = data.EulerAngles.y - previousRotation.y;
        /*if (Mathf.Abs(dif) > threshold)
        {
            temp.y = dif;
        }*/
        temp.y = dif;
        previousRotation.y = data.EulerAngles.y;

        dif = data.EulerAngles.z - previousRotation.z;
        /*if (Mathf.Abs(dif) > threshold)
        {
            temp.z = dif;
        }*/
        temp.z = dif;
        previousRotation.z = data.EulerAngles.z;

        return temp;
    }

}
