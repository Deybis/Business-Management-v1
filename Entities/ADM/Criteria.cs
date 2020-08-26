
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagment.Entities
{
    [DataObject]
    [Serializable]
    public class Criteria
    {
        public Criteria()
        { }
        [DisplayName("Día")]
        [Required(ErrorMessage = "Día es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int Day { get; set; }

        [DisplayName("Mes")]
        [Required(ErrorMessage = "Mes es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int Month { get; set; }


        [DisplayName("Año")]
        [Required(ErrorMessage = "Año es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int Year { get; set; }


        private void InitializeComponent(Object obj)
        {
            Criteria adm_criteria = (Criteria)obj;

            this.Day = adm_criteria.Day;
            this.Month = adm_criteria.Month;
            this.Year = adm_criteria.Year;
        }
    }
    [DataObject]
    [Serializable]
    public class CriteriaCollection : List<Criteria>
    {
        public CriteriaCollection()
        { }
    }
}