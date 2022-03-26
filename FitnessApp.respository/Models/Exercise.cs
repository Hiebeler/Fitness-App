using System;
using System.Collections.Generic;

namespace FitnessApp.respository.Models
{
    public partial class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; } = null!;
        public string? Explanation { get; set; }
        public string? ImageLink { get; set; }
        public int? WorkoutId { get; set; }

        public virtual Workout? Workout { get; set; }
    }
}
