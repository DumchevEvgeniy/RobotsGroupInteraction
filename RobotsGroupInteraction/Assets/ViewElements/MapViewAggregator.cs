using UnityEngine;

namespace Assets.ViewElements {
    public class MapViewAggregator : MonoBehaviour {
        public SmartMap Map { get; set; }

        private void Start() {
            var fieldView = GetComponent<FieldView>();
            if (fieldView == null)
                return;

            var destinationPlaceView = GetComponent<DestinationPlaceView>();
            if (destinationPlaceView == null)
                return;

            var robotViews = GetComponents<RobotView>();
            
            Map = new SmartMap(fieldView.Length, fieldView.Width, new MapFloor(), new ConcreteCube());
            Map.AddElements<RandomPlacementWithPlayerDistance>(new BreakCube(), 10);
            Map.CreateAll();
        }
    }
}
