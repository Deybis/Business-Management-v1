using System;
using System.Data;
using System.Xml;
using BusinessManagment.Factories;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagment.Entities
{
    [DataObject]
    [Serializable]
    public class CXC_IncomeTypes
    {
        public CXC_IncomeTypes()
        { }

        public CXC_IncomeTypes(int incomeTypesID)
        {

            CXC_IncomeTypes cxc_incometypes =
            (CXC_IncomeTypes)factoryCXC_IncomeTypes.getCXC_IncomeTypes(incomeTypesID, myEnums.EntityType.Entity);

            if (cxc_incometypes != null)
            {
                this.IncomeTypesID = cxc_incometypes.IncomeTypesID;
                this.IncomeTypesName = cxc_incometypes.IncomeTypesName;
                this.Note = cxc_incometypes.Note;
                this.CreatedBy = cxc_incometypes.CreatedBy;
                this.CreatedDate = cxc_incometypes.CreatedDate;
                this.ModifiedBy = cxc_incometypes.ModifiedBy;
                this.ModifiedDate = cxc_incometypes.ModifiedDate;

            }
        }

        public CXC_IncomeTypes(String xmlString)
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

        [DisplayName("Income Types")]
        [Required(ErrorMessage = "Income Types es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int IncomeTypesID { get; set; }

        [DisplayName("Income Types Name")]
        [Required(ErrorMessage = "Income Types Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Income Types Name no debe ser mayor de 80 caracteres")]
        public string IncomeTypesName { get; set; }

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


        #region Métodos de la entidad CXC_IncomeTypes


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase Factories.factoryCXC_IncomeTypes representado por Entities.CXC_IncomeTypes como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo CXC_IncomeTypes</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXC_IncomeTypes Select(int incomeTypesID)
        {
            return Factories.factoryCXC_IncomeTypes.getCXC_IncomeTypes(incomeTypesID, myEnums.EntityType.Entity) as Entities.CXC_IncomeTypes;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase Factories.factoryCXC_IncomeTypes persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(CXC_IncomeTypes cxc_incometypes)
        {
            return Factories.factoryCXC_IncomeTypes.saveCXC_IncomeTypes(cxc_incometypes);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase Factories.factoryCXC_IncomeTypes persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(CXC_IncomeTypes cxc_incometypes)
        {
            return Factories.factoryCXC_IncomeTypes.saveCXC_IncomeTypes(cxc_incometypes);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase Factories.factoryCXC_IncomeTypes
        /// </summary>
        /// <param name="cxc_incometypes"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(CXC_IncomeTypes cxc_incometypes)
        {
            return Factories.factoryCXC_IncomeTypes.deleteCXC_IncomeTypes(cxc_incometypes.IncomeTypesID);
        }

        /// <summary>
        /// Devuelve el Objeto CXC_IncomeTypes a una cadena formateada XML
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
            CXC_IncomeTypes cxc_incometypes = (CXC_IncomeTypes)obj;

            this.IncomeTypesID = cxc_incometypes.IncomeTypesID;
            this.IncomeTypesName = cxc_incometypes.IncomeTypesName;
            this.Note = cxc_incometypes.Note;
            this.CreatedBy = cxc_incometypes.CreatedBy;
            this.CreatedDate = cxc_incometypes.CreatedDate;
            this.ModifiedBy = cxc_incometypes.ModifiedBy;
            this.ModifiedDate = cxc_incometypes.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class CXC_IncomeTypesCollection : List<Entities.CXC_IncomeTypes>
    {
        public CXC_IncomeTypesCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de CXC_IncomeTypes a traves de la clase  Factories.factoryCXC_IncomeTypes
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.CXC_IncomeTypesCollection Select()
        {
            return Factories.factoryCXC_IncomeTypes.getCXC_IncomeTypes(0, myEnums.EntityType.EntityCollection) as Entities.CXC_IncomeTypesCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo CXC_IncomeTypesCollection con un solo registro  a traves de la clase  Factories.factoryCXC_IncomeTypes
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXC_IncomeTypesCollection Select(int incomeTypesID)
        {
            return Factories.factoryCXC_IncomeTypes.getCXC_IncomeTypes(incomeTypesID, myEnums.EntityType.EntityCollection) as Entities.CXC_IncomeTypesCollection;
        }
    }
}