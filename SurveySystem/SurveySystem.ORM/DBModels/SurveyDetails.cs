namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SurveyDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QDID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid UserInfoID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionnaireID { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        public virtual QuestionnaireDetails QuestionnaireDetails { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
