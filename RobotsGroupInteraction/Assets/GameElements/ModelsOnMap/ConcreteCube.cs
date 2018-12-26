public class FoundationCube : DynamicGameObject {
    public const string tag = ElementTag.FoundationCube;
    
    protected override string GetPrefabName() => PrefabTypes.ConcreteCube;
}