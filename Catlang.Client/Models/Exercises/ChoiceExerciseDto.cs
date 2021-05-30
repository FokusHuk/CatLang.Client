using System;
using System.Collections.Generic;

namespace Catlang.Client.Models
{
    public class ChoiceExerciseDto
    {
        public ChoiceExerciseDto(Guid id, Guid setId, List<ChoiceExerciseTaskDto> tasks)
        {
            Id = id;
            SetId = setId;
            Tasks = tasks;
        }

        public Guid Id { get; }
        public Guid SetId { get; }
        public List<ChoiceExerciseTaskDto> Tasks { get; }
    }
}
