using System;
using System.ComponentModel.DataAnnotations;

namespace ScrumBoard.Models {
    public class ToDo {
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255, MinimumLength = 1)]
        public string Title { get; set; }
        public State State { get; set; }
        [Before(nameof(DueDate))]
        public DateTime StartDate { get; set; }
        [After(nameof(StartDate))]
        public DateTime DueDate { get; set; }

        public bool StartDatePassed() {
            if (State < State.Doing && StartDate < DateTime.Now)
                return true;
            return false;
        }

        public bool DueDatePassed() {
            if (State != State.Done && DueDate < DateTime.Now)
                return true;
            return false;
        }
    }
}
