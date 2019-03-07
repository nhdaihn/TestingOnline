namespace TestingSystem.DataTranferObject.Question
{
    using System;

    /// <summary>
    /// Defines the <see cref="QuestionFilterModel" />
    /// </summary>
    public class QuestionFilterModel
    {
        /// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        public int? QuestionID { get; set; }

        /// <summary>
        /// Gets or sets the Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the Level
        /// </summary>
        public int? Level { get; set; }

        /// <summary>
        /// Gets or sets the CategoryID
        /// </summary>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }
    }
}
