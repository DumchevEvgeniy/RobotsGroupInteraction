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

        var map = new SmartMap(fieldView.Length, fieldView.Width, new ConcreteCube(), new ConcreteCube());
        map.AddElements<RandomEmptyPlacementSearcher>(new BreakCube(), 10);

        //map.AddElements<RandomEmptyPlacementSearcher>(new Robot())
        //роботов
        //препятствия

        //в основании сделать кубы - подкрашивать входящие в область пребытия

        map.CreateAll();
    }
}
