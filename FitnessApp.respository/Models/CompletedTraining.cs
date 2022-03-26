using System;
using System.Collections.Generic;

namespace FitnessApp.respository.Models
{
    public partial class CompletedTraining
    {
        public int Id { get; set; }
        public Guid? UserUid { get; set; }
        public int? WorkoutId { get; set; }
        public TimeOnly? Duration { get; set; }

        public virtual User? UserU { get; set; }
        public virtual Workout? Workout { get; set; }
    }
}
