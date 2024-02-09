using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestApi_1.Model
{
    public record Exercise
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public ExerciseIntensity Intensity { get; init; }
        public int RecommendedDurationInSeconds { get; init; }
        public int RecommendedTimeInSecondsBeforeExercise { get; init; }
        public int RecommendedTimeInSecondsAfterExercise { get; init; }
        public string? RestTimeInstructions { get; init; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ExerciseIntensity
        {
            Low = 1,
            Normal = 2,
            High = 3
        }
    }
}