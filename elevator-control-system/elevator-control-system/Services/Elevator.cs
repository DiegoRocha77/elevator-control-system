using elevator_control_system.IServices;

namespace elevator_control_system.Services
{
    public class Elevator: IElevator
    {
        private List<int> _allFloos = new List<int> { 1, 2, 3,4,5,6,7 };
        private List<int> _requestedFloors = new List<int>();
        private int _elevatorCurrentFloor;


        public Elevator() {
            _elevatorCurrentFloor = _allFloos[0];
        }

        public string MoveElevatorToSpecificFloor(int floor)
        {
            try
            {
                _requestedFloors.Add(floor);
                MoveElevator();
                return $"current floor is{_elevatorCurrentFloor}";
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
           
        }

        public string ListOfFloorsRequests(List<int> floors)
        {
            try
            {
                _requestedFloors.AddRange(floors);
                MoveElevator();
                return Constants.Success;
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
          
        }
        public string MoveToNextFloor(string direction)
        {
            try
            {
                if (_elevatorCurrentFloor == _allFloos[0] & direction == Constants.DirectionDown)
                    return Constants.NotAbleToMove;
                else if (_elevatorCurrentFloor == _allFloos[_allFloos.Count] & direction == Constants.DirectionUp)
                    return Constants.NotAbleToMove;
                else if (direction == Constants.DirectionDown)
                    MoveElevatorToSpecificFloor(_elevatorCurrentFloor - 1);
                else if (direction == Constants.DirectionUp)
                    MoveElevatorToSpecificFloor(_elevatorCurrentFloor + 1);

                return Constants.Success;
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }

        private void MoveElevator() {
            if (_requestedFloors.Count > 0) {
                foreach (var floor in _allFloos)
                {
                    if (_requestedFloors.Contains(floor))
                    {
                        _requestedFloors.Remove(floor);
                        _elevatorCurrentFloor = floor;
                    }
                    if (_requestedFloors.Count == 0)
                        break;
                }
            }
           
           
        }
    }
}
