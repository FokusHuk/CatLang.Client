using Catlang.Client.Models;
using System;

namespace Catlang.Client
{
    public static class StaticExerciseStorage
    {
        public static Guid ExerciseId { get; set; }
        public static Guid SetId { get; set; }
        public static string SetName { get; set; }
        public static ExerciseFormat ExerciseFormat { get;set; }
    }
}
