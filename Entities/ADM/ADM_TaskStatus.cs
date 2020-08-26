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
    public class ADM_TaskStatus
    {
        public ADM_TaskStatus()
        { }

        public ADM_TaskStatus(int taskStatusID)
        {

            ADM_TaskStatus adm_taskstatus =
            (ADM_TaskStatus)factoryADM_TaskStatus.getADM_TaskStatus(taskStatusID, myEnums.EntityType.Entity);

            if (adm_taskstatus != null)
            {
                this.TaskStatusID = adm_taskstatus.TaskStatusID;
                this.TaskStatusName = adm_taskstatus.TaskStatusName;
                this.IsActive = adm_taskstatus.IsActive;
                this.Note = adm_taskstatus.Note;
                this.CreatedBy = adm_taskstatus.CreatedBy;
                this.CreatedDate = adm_taskstatus.CreatedDate;
                this.ModifiedBy = adm_taskstatus.ModifiedBy;
                this.ModifiedDate = adm_taskstatus.ModifiedDate;

            }
        }

        public ADM_TaskStatus(String xmlString)
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

        [DisplayName("Task Status")]
        [Required(ErrorMessage = "Task Status es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int TaskStatusID { get; set; }

        [DisplayName("Task Status Name")]
        [Required(ErrorMessage = "Task Status Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Task Status Name no debe ser mayor de 80 caracteres")]
        public string TaskStatusName { get; set; }

        [DisplayName("Is Active")]
        [ScaffoldColumn(true)]
        public bool IsActive { get; set; }

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


        #region Métodos de la entidad ADM_TaskStatus


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase factorys.factoryADM_TaskStatus representado por Entities.ADM_TaskStatus como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo ADM_TaskStatus</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.ADM_TaskStatus Select(int taskStatusID)
        {
            return factoryADM_TaskStatus.getADM_TaskStatus(taskStatusID, myEnums.EntityType.Entity) as Entities.ADM_TaskStatus;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase factorys.factoryADM_TaskStatus persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(ADM_TaskStatus adm_taskstatus)
        {
            return factoryADM_TaskStatus.saveADM_TaskStatus(adm_taskstatus);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase factorys.factoryADM_TaskStatus persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(ADM_TaskStatus adm_taskstatus)
        {
            return factoryADM_TaskStatus.saveADM_TaskStatus(adm_taskstatus);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase factorys.factoryADM_TaskStatus
        /// </summary>
        /// <param name="adm_taskstatus"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(ADM_TaskStatus adm_taskstatus)
        {
            return factoryADM_TaskStatus.deleteADM_TaskStatus(adm_taskstatus.TaskStatusID);
        }

        /// <summary>
        /// Devuelve el Objeto ADM_TaskStatus a una cadena formateada XML
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
            ADM_TaskStatus adm_taskstatus = (ADM_TaskStatus)obj;

            this.TaskStatusID = adm_taskstatus.TaskStatusID;
            this.TaskStatusName = adm_taskstatus.TaskStatusName;
            this.IsActive = adm_taskstatus.IsActive;
            this.Note = adm_taskstatus.Note;
            this.CreatedBy = adm_taskstatus.CreatedBy;
            this.CreatedDate = adm_taskstatus.CreatedDate;
            this.ModifiedBy = adm_taskstatus.ModifiedBy;
            this.ModifiedDate = adm_taskstatus.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class ADM_TaskStatusCollection : List<Entities.ADM_TaskStatus>
    {
        public ADM_TaskStatusCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de ADM_TaskStatus a traves de la clase  factorys.factoryADM_TaskStatus
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.ADM_TaskStatusCollection Select()
        {
            return factoryADM_TaskStatus.getADM_TaskStatus(0, myEnums.EntityType.EntityCollection) as Entities.ADM_TaskStatusCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo ADM_TaskStatusCollection con un solo registro  a traves de la clase  factorys.factoryADM_TaskStatus
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.ADM_TaskStatusCollection Select(int taskStatusID)
        {
            return factoryADM_TaskStatus.getADM_TaskStatus(taskStatusID, myEnums.EntityType.EntityCollection) as Entities.ADM_TaskStatusCollection;
        }
    }
}