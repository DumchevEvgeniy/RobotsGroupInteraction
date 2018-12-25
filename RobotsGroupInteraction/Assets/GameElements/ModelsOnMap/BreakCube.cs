using UnityEngine;

public class BreakCube : DynamicGameObject {
    public const string tag = "BreakCube";

    protected override string GetPrefabName() => PrefabTypes.BreakCube;

    protected override GameObject CreateGameObject() {
        var sandCube = base.CreateGameObject();
        sandCube.AddComponent<BreakCubeSettings>();
        return sandCube;
    }
}
