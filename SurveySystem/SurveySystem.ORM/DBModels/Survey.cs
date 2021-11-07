namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey")]
    public partial class Survey
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserInfoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionnaireID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Caption { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
