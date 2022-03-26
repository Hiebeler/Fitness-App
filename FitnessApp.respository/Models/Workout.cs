using System;
using System.Collections.Generic;

namespace FitnessApp.respository.Models
{
    public partial class Workout
    {
        public Workout()
        {
            CompletedTrainings = new HashSet<CompletedTraining>();
            Exercises = new HashSet<Exercise>();
        }

        public int Id { get; set; }
        public Guid? UserUid { get; set; }
        public string? ImageLink { get; set; }
        public string WorkoutName { get; set; } = null!;
        public string? Description { get; set; }
        public TimeOnly? Duration { get; set; }

        public virtual User? UserU { get; set; }
        public virtual ICollection<CompletedTraining> CompletedTrainings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
