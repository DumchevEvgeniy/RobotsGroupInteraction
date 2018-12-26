using System;
using System.Linq;
using UnityEngine;

public static class GameObjectExtensions {
    public static GameObject SetPosition(this GameObject gameObject, Single x, Single y, Single z) {
        gameObject.transform.position.Set(x, y, z);
        return gameObject;
    }
    public static GameObject SetPosition(this GameObject gameObject, Coordinate coordinate, Single value) {
        gameObject.transform.position = gameObject.transform.position.Set(coordinate, value);
        return gameObject;
    }

    public static GameObject GetParent(this GameObject gameObject) {
        var parentObject = gameObject;
        while (parentObject.transform.parent != null)
            parentObject = parentObject.transform.parent.gameObject;
        return parentObject;
    }

    public static Vector3 GetIntegerPosition(this GameObject gameObject) {
        var position = gameObject.transform.position;
        return new Vector3((Int32)Math.Round(position.x), (Int32)Math.Round(position.y), (Int32)Math.Round(position.z));
    }

    public static Boolean OneFrom(this GameObject gameObject, params String[] tags) {
        if (tags == null || tags.Length == 0)
            return false;
        return tags.Any(tag => gameObject.CompareTag(tag));
    }
}
