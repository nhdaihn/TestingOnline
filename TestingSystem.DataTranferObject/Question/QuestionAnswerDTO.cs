namespace TestingSystem.DataTranferObject.Question
{
    using System.Collections.Generic;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="QuestionAnswerDTO" />
    /// </summary>
    public class QuestionAnswerDTO
    {
        /// <summary>
        /// Gets or sets the Question
        /// </summary>
        public Models.Question Question { get; set; }

        /// <summary>
        /// Gets or sets the Answers
        /// </summary>
        public ICollection<Answer> Answers { get; set; }
    }
}
