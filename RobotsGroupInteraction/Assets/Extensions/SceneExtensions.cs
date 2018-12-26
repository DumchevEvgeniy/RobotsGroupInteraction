using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneExtensions {
    public static GameObject FindRobot(this Scene scene) => GetAllElementsByTag(scene, Robot.tag).FirstOrDefault();
    public static GameObject FindMainCamera(this Scene scene) => scene.GetAllElementsByTag("MainCamera").FirstOrDefault();

    public static IEnumerable<GameObject> FindAllBreakCube(this Scene scene) => GetAllElementsByTag(scene, BreakCube.tag);
    public static IEnumerable<GameObject> FindAllFoundationCubes(this Scene scene) => GetAllElementsByTag(scene, FoundationCube.tag);
    public static IEnumerable<GameObject> GetAllElementsByTag(this Scene scene, String tag) => 
        scene.GetRootGameObjects().Where(g => g.CompareTag(tag));

    //public static Field GetField(this Scene scene) {
    //    var map = scene.GetAllElementsByTag("Map").FirstOrDefault();
    //    if(map == null)
    //        return null;
    //    var level = map.GetComponent<MapViewAggregator>();
    //    if(level == null)
    //        return null;
    //    return level.Map.Field;
    //}
}
