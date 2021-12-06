namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuestionnaireDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionnaireDetails()
        {
            SurveyDetails = new HashSet<SurveyDetails>();
        }

        [Key]
        public int QDID { get; set; }

        public int QuestionnaireID { get; set; }

        [Required]
        [StringLength(50)]
        public string QuestionType { get; set; }

        [Required]
        [StringLength(50)]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string QOption { get; set; }

        [Required]
        [StringLength(10)]
        public string Required { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SurveyDetails> SurveyDetails { get; set; }
    }
}
