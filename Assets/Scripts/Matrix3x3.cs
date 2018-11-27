using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Matrix3x3
{

    public enum AxisId
    {
        x, y, z
    };


    public float m00, m01, m02;
    public float m10, m11, m12;
    public float m20, m21, m22;

    public Matrix3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
    {
        this.m00 = m00;
        this.m01 = m01;
        this.m02 = m02;

        this.m10 = m10;
        this.m11 = m11;
        this.m12 = m12;

        this.m20 = m20;
        this.m21 = m21;
        this.m22 = m22;
    }

	public Matrix3x3 Rotate(float angleInDeg,  AxisId axis) 
    {
        float angleInRad = Mathf.Deg2Rad * angleInDeg;
        switch (axis)
        {
            case AxisId.x:
                return new Matrix3x3(1, 0, 0,
                                     0, Mathf.Cos(angleInRad), Mathf.Sin(angleInRad) * -1,
                                     0, Mathf.Sin(angleInRad), Mathf.Cos(angleInRad)
                                     );

            case AxisId.y:
                return new Matrix3x3(Mathf.Cos(angleInRad), 0, Mathf.Sin(angleInRad),
                                     0, 1, 0,
                                     Mathf.Sin(angleInRad) * -1, 0, Mathf.Cos(angleInRad)
                                     );

            case AxisId.z:
                return new Matrix3x3(Mathf.Cos(angleInRad), Mathf.Sin(angleInRad) * -1, 0,
                                     Mathf.Sin(angleInRad), Mathf.Cos(angleInRad), 0,
                                     0, 0, 1);
        }

        return new Matrix3x3(0, 0, 0, 0, 0, 0, 0, 0, 0);
    }
   
    public Matrix3x3 Euler(Vector3 eulerAngles)
    {
        Matrix3x3 R_x = new Matrix3x3(1, 0, 0,
                                      0, Mathf.Cos(eulerAngles.x), Mathf.Sin(eulerAngles.x) * -1,
                                      0, Mathf.Sin(eulerAngles.x), Mathf.Cos(eulerAngles.x)
                                      );

        Matrix3x3 R_y = new Matrix3x3(Mathf.Cos(eulerAngles.y), 0, Mathf.Sin(eulerAngles.y),
                                      0, 1, 0,
                                      Mathf.Sin(eulerAngles.y) * -1, 0, Mathf.Cos(eulerAngles.y)
                                     );

        Matrix3x3 R_z = new Matrix3x3(Mathf.Cos(eulerAngles.z), Mathf.Sin(eulerAngles.z) * -1, 0,
                                      Mathf.Sin(eulerAngles.z), Mathf.Cos(eulerAngles.z), 0,
                                      0, 0, 1);

        Matrix3x3 R =  R_y * R_x * R_z;

        return R;
    }

    static Matrix3x3 Euler(float x, float y, float z)
    {
        Matrix3x3 R_x = new Matrix3x3(1, 0, 0,
                                      0, Mathf.Cos(x), Mathf.Sin(x) * -1,
                                      0, Mathf.Sin(x), Mathf.Cos(x)
                                      );

        Matrix3x3 R_y = new Matrix3x3(Mathf.Cos(y), 0, Mathf.Sin(y),
                                      0, 1, 0,
                                      Mathf.Sin(y) * -1, 0, Mathf.Cos(y)
                                     );

        Matrix3x3 R_z = new Matrix3x3(Mathf.Cos(z), Mathf.Sin(z) * -1, 0,
                                      Mathf.Sin(z), Mathf.Cos(z), 0,
                                      0, 0, 1);

        Matrix3x3 R = R_x * R_y * R_z;

        return R;
    }

    public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
    {
        Matrix3x3 multiplication = new Matrix3x3();

        multiplication.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20;
        multiplication.m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21;
        multiplication.m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22;

        multiplication.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20;
        multiplication.m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21;
        multiplication.m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22;

        multiplication.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20;
        multiplication.m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21;
        multiplication.m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22;

        return multiplication;
    }

    public static Vector3 operator *(Matrix3x3 m, Vector3 v)
    {
        Vector3 result;
        result.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z;
        result.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z;
        result.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z;

        return result;
    }

}
