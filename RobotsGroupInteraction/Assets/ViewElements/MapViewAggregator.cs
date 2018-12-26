using System.Linq;
using UnityEngine;

public class MapViewAggregator : MonoBehaviour {
    private void Start() {
        var fieldView = GetComponent<FieldView>();
        if (fieldView == null)
            return;

        var destinationPlaceView = GetComponent<DestinationPlaceView>();
        if (destinationPlaceView == null)
            return;

        var robotViews = GetComponents<RobotView>();

        var map = new SmartMap(fieldView.Length, fieldView.Width, new FoundationCube(), new FoundationCube());
        map.AddElements<RandomEmptyPlacementSearcher>(new BreakCube(), 10);

        //map.AddElements<RandomEmptyPlacementSearcher>(new Robot())
        //роботов
        //препятствия

        //в основании сделать кубы - подкрашивать входящие в область пребытия

        map.CreateAll();

        var destinationCubes = gameObject.scene.FindAllFoundationCubes().Where(element =>
            element.transform.position.x.ToInt32() >= destinationPlaceView.LeftTopCornerX &&
            element.transform.position.x.ToInt32() <= destinationPlaceView.RightBottomCornerX &&
            element.transform.position.z.ToInt32() >= destinationPlaceView.LeftTopCornerY &&
            element.transform.position.z.ToInt32() <= destinationPlaceView.RightBottomCornerY &&
            element.transform.position.y.ToInt32() == 0).ToList();

        foreach(var destinationCube in destinationCubes) {
            destinationCube.tag = ElementTag.DestinationCube;

            var renderer = destinationCube.GetComponent<Renderer>();
            renderer.material = new Material(PrefabTypes.Material); //работает не так как нужно
        }
    }
}
