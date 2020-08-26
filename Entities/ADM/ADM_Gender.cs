using System;
using System.Data;
using System.Xml;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessManagment.Factories;

namespace BusinessManagment.Entities
{
    [DataObject]
    [Serializable]
    public class ADM_Gender
    {
        public ADM_Gender()
        { }

        public ADM_Gender(int genderID)
        {

            ADM_Gender adm_gender =
            (ADM_Gender)factoryADM_Gender.getADM_Gender(genderID, myEnums.EntityType.Entity);

            if (adm_gender != null)
            {
                this.GenderID = adm_gender.GenderID;
                this.GenderName = adm_gender.GenderName;
                this.Note = adm_gender.Note;
                this.CreatedBy = adm_gender.CreatedBy;
                this.CreatedDate = adm_gender.CreatedDate;
                this.ModifiedBy = adm_gender.ModifiedBy;
                this.ModifiedDate = adm_gender.ModifiedDate;

            }
        }

        public ADM_Gender(String xmlString)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Inicializamos/Construimos la clase con los valores de las propiedades 
            InitializeComponent(obj);
        }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int GenderID { get; set; }

        [DisplayName("Gender Name")]
        [Required(ErrorMessage = "Gender Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Gender Name no debe ser mayor de 50 caracteres")]
        public string GenderName { get; set; }

        [DisplayName("Note")]
        [ScaffoldColumn(true)]
        [StringLength(250, ErrorMessage = "Note no debe ser mayor de 250 caracteres")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [DisplayName("Created By")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Created By no debe ser mayor de 50 caracteres")]
        public string CreatedBy { get; set; }

        [DisplayName("Created Date")]
        [ScaffoldColumn(true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Modified By")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Modified By no debe ser mayor de 50 caracteres")]
        public string ModifiedBy { get; set; }

        [DisplayName("Modified Date")]
        [ScaffoldColumn(true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }


        #region Métodos de la entidad ADM_Gender


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase factorys.factoryADM_Gender representado por Entities.ADM_Gender como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo ADM_Gender</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.ADM_Gender Select(int genderID)
        {
            return factoryADM_Gender.getADM_Gender(genderID, myEnums.EntityType.Entity) as Entities.ADM_Gender;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase factorys.factoryADM_Gender persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(ADM_Gender adm_gender)
        {
            return Factories.factoryADM_Gender.saveADM_Gender(adm_gender);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase factorys.factoryADM_Gender persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(ADM_Gender adm_gender)
        {
            return Factories.factoryADM_Gender.saveADM_Gender(adm_gender);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase factorys.factoryADM_Gender
        /// </summary>
        /// <param name="adm_gender"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(ADM_Gender adm_gender)
        {
            return Factories.factoryADM_Gender.deleteADM_Gender(adm_gender.GenderID);
        }

        /// <summary>
        /// Devuelve el Objeto ADM_Gender a una cadena formateada XML
        /// </summary>
        /// <returns></returns>
        public string ToXMLString()
        {
            System.IO.StringWriter xmlString = new System.IO.StringWriter();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            x.Serialize(xmlString, this);

            return xmlString.ToString();
        }

        private void InitializeComponent(Object obj)
        {
            ADM_Gender adm_gender = (ADM_Gender)obj;

            this.GenderID = adm_gender.GenderID;
            this.GenderName = adm_gender.GenderName;
            this.Note = adm_gender.Note;
            this.CreatedBy = adm_gender.CreatedBy;
            this.CreatedDate = adm_gender.CreatedDate;
            this.ModifiedBy = adm_gender.ModifiedBy;
            this.ModifiedDate = adm_gender.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class ADM_GenderCollection : List<Entities.ADM_Gender>
    {
        public ADM_GenderCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de ADM_Gender a traves de la clase  factorys.factoryADM_Gender
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.ADM_GenderCollection Select()
        {
            return Factories.factoryADM_Gender.getADM_Gender(0, myEnums.EntityType.EntityCollection) as Entities.ADM_GenderCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo ADM_GenderCollection con un solo registro  a traves de la clase  factorys.factoryADM_Gender
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.ADM_GenderCollection Select(int genderID)
        {
            return Factories.factoryADM_Gender.getADM_Gender(genderID, myEnums.EntityType.EntityCollection) as Entities.ADM_GenderCollection;
        }
    }
}