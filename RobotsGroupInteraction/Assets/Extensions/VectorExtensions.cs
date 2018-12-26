using System;
using UnityEngine;

public static class VectorExtensions {
    public static Cell ToCell(this Vector3 vector) => new Cell((Int32)vector.x, (Int32)vector.z);

    public static Vector3 Set(this Vector3 vector, Coordinate coordinate, Single value) {
        switch (coordinate) {
            case Coordinate.X:
                vector.Set(value, vector.y, vector.z);
                break;
            case Coordinate.Y:
                vector.Set(vector.x, value, vector.z);
                break;
            case Coordinate.Z:
                vector.Set(vector.x, vector.y, value);
                break;
        }
        return vector;
    }

    public static Int32 Sign(this Vector3 vector) {
        var sign = Math.Sign(vector.x);
        if (sign != 0)
            return sign;
        sign = Math.Sign(vector.y);
        if (sign != 0)
            return sign;
        return Math.Sign(vector.z);
    }
}

