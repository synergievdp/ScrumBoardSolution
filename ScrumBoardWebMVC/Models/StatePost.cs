using ScrumBoard.Models;
using System;

namespace ScrumBoardWebMVC.Models
{
    public class StatePost
    {
        public string Id { get; set; }
        public string State { get; set; }

        public State GetState()
        {
            _ = Enum.TryParse(State, out State state);
            return state;
        }

        public int GetId()
        {
            return int.Parse(Id);
        }
    }
}
