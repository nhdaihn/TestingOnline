namespace TestingSystem.DataTranferObject
{
    using System;

    /// <summary>
    /// Defines the <see cref="ExamPaperFilterModel" />
    /// </summary>
    public class ExamPaperFilterModel
    {
        /// <summary>
        /// Gets or sets the ExamPaperID
        /// </summary>
        public int? ExamPaperID { get; set; }

        /// <summary>
        /// Gets or sets the Time
        /// </summary>
        public int? Time { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or sets the NumberOfQuestion
        /// </summary>
        public int? NumberOfQuestion { get; set; }

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
