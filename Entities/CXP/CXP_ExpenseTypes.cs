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
    public class CXP_ExpenseTypes
    {
        public CXP_ExpenseTypes()
        { }

        public CXP_ExpenseTypes(int expenseTypesID)
        {

            CXP_ExpenseTypes cxp_expensetypes =
            (CXP_ExpenseTypes)factoryCXP_ExpenseTypes.getCXP_ExpenseTypes(expenseTypesID, myEnums.EntityType.Entity);

            if (cxp_expensetypes != null)
            {
                this.ExpenseTypesID = cxp_expensetypes.ExpenseTypesID;
                this.ExpenseTypesName = cxp_expensetypes.ExpenseTypesName;
                this.Note = cxp_expensetypes.Note;
                this.CreatedBy = cxp_expensetypes.CreatedBy;
                this.CreatedDate = cxp_expensetypes.CreatedDate;
                this.ModifiedBy = cxp_expensetypes.ModifiedBy;
                this.ModifiedDate = cxp_expensetypes.ModifiedDate;

            }
        }

        public CXP_ExpenseTypes(String xmlString)
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

        [DisplayName("Expense Types")]
        [Required(ErrorMessage = "Expense Types es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int ExpenseTypesID { get; set; }

        [DisplayName("Expense Types Name")]
        [Required(ErrorMessage = "Expense Types Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Expense Types Name no debe ser mayor de 80 caracteres")]
        public string ExpenseTypesName { get; set; }

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


        #region Métodos de la entidad CXP_ExpenseTypes


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase factorys.factoryCXP_ExpenseTypes representado por Entities.CXP_ExpenseTypes como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo CXP_ExpenseTypes</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXP_ExpenseTypes Select(int expenseTypesID)
        {
            return Factories.factoryCXP_ExpenseTypes.getCXP_ExpenseTypes(expenseTypesID, myEnums.EntityType.Entity) as Entities.CXP_ExpenseTypes;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase factorys.factoryCXP_ExpenseTypes persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(CXP_ExpenseTypes cxp_expensetypes)
        {
            return Factories.factoryCXP_ExpenseTypes.saveCXP_ExpenseTypes(cxp_expensetypes);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase factorys.factoryCXP_ExpenseTypes persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(CXP_ExpenseTypes cxp_expensetypes)
        {
            return Factories.factoryCXP_ExpenseTypes.saveCXP_ExpenseTypes(cxp_expensetypes);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase factorys.factoryCXP_ExpenseTypes
        /// </summary>
        /// <param name="cxp_expensetypes"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(CXP_ExpenseTypes cxp_expensetypes)
        {
            return Factories.factoryCXP_ExpenseTypes.deleteCXP_ExpenseTypes(cxp_expensetypes.ExpenseTypesID);
        }

        /// <summary>
        /// Devuelve el Objeto CXP_ExpenseTypes a una cadena formateada XML
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
            CXP_ExpenseTypes cxp_expensetypes = (CXP_ExpenseTypes)obj;

            this.ExpenseTypesID = cxp_expensetypes.ExpenseTypesID;
            this.ExpenseTypesName = cxp_expensetypes.ExpenseTypesName;
            this.Note = cxp_expensetypes.Note;
            this.CreatedBy = cxp_expensetypes.CreatedBy;
            this.CreatedDate = cxp_expensetypes.CreatedDate;
            this.ModifiedBy = cxp_expensetypes.ModifiedBy;
            this.ModifiedDate = cxp_expensetypes.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class CXP_ExpenseTypesCollection : List<Entities.CXP_ExpenseTypes>
    {
        public CXP_ExpenseTypesCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de CXP_ExpenseTypes a traves de la clase  factorys.factoryCXP_ExpenseTypes
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.CXP_ExpenseTypesCollection Select()
        {
            return Factories.factoryCXP_ExpenseTypes.getCXP_ExpenseTypes(0, myEnums.EntityType.EntityCollection) as Entities.CXP_ExpenseTypesCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo CXP_ExpenseTypesCollection con un solo registro  a traves de la clase  factorys.factoryCXP_ExpenseTypes
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXP_ExpenseTypesCollection Select(int expenseTypesID)
        {
            return Factories.factoryCXP_ExpenseTypes.getCXP_ExpenseTypes(expenseTypesID, myEnums.EntityType.EntityCollection) as Entities.CXP_ExpenseTypesCollection;
        }
    }
}