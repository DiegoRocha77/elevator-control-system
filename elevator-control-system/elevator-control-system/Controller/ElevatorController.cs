using elevator_control_system.IServices;
using Microsoft.AspNetCore.Mvc;

namespace elevator_control_system.Controller
{
    [ApiController]
    [Route("api/elevator")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevator _elevator;
        public ElevatorController(IElevator elevator)
        {
            _elevator = elevator;
        }
        [HttpGet]
        [Route("GetOnCurrentFloor/{floor}")]
        public IActionResult GetOnCurrentFloor(int floor)
        {
            string response  = _elevator.MoveElevatorToSpecificFloor(floor);
            return Ok(response);
        }

        [HttpGet]
        [Route("BroughtToFloor/{floor}")]
        public IActionResult BroughtToFloor(int floor)
        {
            string response =  _elevator.MoveElevatorToSpecificFloor(floor);
            return Ok(response);
        }

        [HttpPost]
        [Route("elevatorRequestsAll")]
        public IActionResult elevatorRequestsAll([FromBody] List<int> floors)
        {
            string response =  _elevator.ListOfFloorsRequests(floors);
            return Ok(response);
        }

        [HttpGet]
        [Route("elevatorRequestsNext/{direction}")]
        public IActionResult elevatorRequestsNext(string direction)
        {
            string response = _elevator.MoveToNextFloor(direction);
            return Ok(response);
        }
    }
}
