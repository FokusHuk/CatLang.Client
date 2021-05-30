using System;
using System.Collections.Generic;

namespace Catlang.Client.Models
{
    public class ConformityExerciseDto
    {
        public ConformityExerciseDto(Guid id, Guid setId, List<ConformityExerciseTaskDto> tasks)
        {
            Id = id;
            SetId = setId;
            Tasks = tasks;
        }

        public Guid Id { get; }
        public Guid SetId { get; }
        public List<ConformityExerciseTaskDto> Tasks { get; }
    }
}
