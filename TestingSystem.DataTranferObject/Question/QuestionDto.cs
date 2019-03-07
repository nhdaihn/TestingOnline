namespace TestingSystem.DataTranferObject.Question
{
    using System;

    /// <summary>
    /// Defines the <see cref="QuestionDto" />
    /// </summary>
    public class QuestionDto
    {
        /// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        public int QuestionID { get; set; }

        /// <summary>
        /// Gets or sets the Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the LevelName
        /// </summary>
        public string LevelName { get; set; }

        /// <summary>
        /// Gets or sets the CategoryID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy
        /// </summary>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedDate
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the ExamPaperQuestionID
        /// </summary>
        public int? ExamPaperQuestionID { get; set; }
    }
}
