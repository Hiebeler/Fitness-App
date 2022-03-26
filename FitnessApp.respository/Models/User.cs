using System;
using System.Collections.Generic;

namespace FitnessApp.respository.Models
{
    public partial class User
    {
        public User()
        {
            CompletedTrainings = new HashSet<CompletedTraining>();
            Workouts = new HashSet<Workout>();
        }

        public Guid Uid { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<CompletedTraining> CompletedTrainings { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
