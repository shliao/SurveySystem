namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserInfoSurvey_View
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
        public DateTime CreatDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public Guid Expr1 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string MobilePhone { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(3)]
        public string Age { get; set; }
    }
}
