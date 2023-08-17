namespace elevator_control_system.IServices
{
    public interface IElevator
    {
       public string MoveElevatorToSpecificFloor(int floor);
       public string ListOfFloorsRequests(List<int> floors);
       public string MoveToNextFloor(string floor);
    }
}
