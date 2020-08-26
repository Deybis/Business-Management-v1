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
    public class ADM_Tasks
    {
        public ADM_Tasks()
        { }

        public ADM_Tasks(long taskID,string accountLoginUser)
        {

            ADM_Tasks adm_tasks =
            (ADM_Tasks)factoryADM_Tasks.getADM_Tasks(taskID,accountLoginUser, myEnums.EntityType.Entity);

            if (adm_tasks != null)
            {
                this.TaskID = adm_tasks.TaskID;
                this.AccountID = adm_tasks.AccountID;
                this.TaskStatusID = adm_tasks.TaskStatusID;
                this.TaskStatusName = adm_tasks.TaskStatusName;
                this.TaskName = adm_tasks.TaskName;
                this.TaskDate = adm_tasks.TaskDate;
                this.Note = adm_tasks.Note;
                this.CreatedBy = adm_tasks.CreatedBy;
                this.CreatedDate = adm_tasks.CreatedDate;
                this.ModifiedBy = adm_tasks.ModifiedBy;
                this.ModifiedDate = adm_tasks.ModifiedDate;

            }
        }

        public ADM_Tasks(String xmlString)
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

        [DisplayName("Task")]
        [Required(ErrorMessage = "Task es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public long TaskID { get; set; }

        [DisplayName("Account")]
        [Required(ErrorMessage = "Account es un campo obligatorio")]
        [ScaffoldColumn(true)]
        public long AccountID { get; set; }

        [DisplayName("Task Status")]
        [Required(ErrorMessage = "Task Status es un campo obligatorio")]
        [ScaffoldColumn(true)]
        public int TaskStatusID { get; set; }

        [DisplayName("Status Name")]
        [Required(ErrorMessage = "Status Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Status Name no debe ser mayor de 200 caracteres")]
        public string TaskStatusName { get; set; }

        [DisplayName("Task Name")]
        [Required(ErrorMessage = "Task Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(200, ErrorMessage = "Task Name no debe ser mayor de 200 caracteres")]
        public string TaskName { get; set; }

        [DisplayName("Task Date")]
        [ScaffoldColumn(true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime TaskDate { get; set; }

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


        #region Métodos de la entidad ADM_Tasks


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase factorys.factoryADM_Tasks representado por Entities.ADM_Tasks como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo ADM_Tasks</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.ADM_Tasks Select(long taskID,string accountLoginUser)
        {
            return factoryADM_Tasks.getADM_Tasks(taskID,accountLoginUser, myEnums.EntityType.Entity) as Entities.ADM_Tasks;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase factorys.factoryADM_Tasks persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(ADM_Tasks adm_tasks)
        {
            return factoryADM_Tasks.saveADM_Tasks(adm_tasks);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase factorys.factoryADM_Tasks persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(ADM_Tasks adm_tasks)
        {
            return factoryADM_Tasks.saveADM_Tasks(adm_tasks);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase factorys.factoryADM_Tasks
        /// </summary>
        /// <param name="adm_tasks"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(ADM_Tasks adm_tasks)
        {
            return factoryADM_Tasks.deleteADM_Tasks(adm_tasks.TaskID);
        }

        /// <summary>
        /// Devuelve el Objeto ADM_Tasks a una cadena formateada XML
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
            ADM_Tasks adm_tasks = (ADM_Tasks)obj;

            this.TaskID = adm_tasks.TaskID;
            this.AccountID = adm_tasks.AccountID;
            this.TaskStatusID = adm_tasks.TaskStatusID;
            this.TaskStatusName = adm_tasks.TaskStatusName;
            this.TaskName = adm_tasks.TaskName;
            this.TaskDate = adm_tasks.TaskDate;
            this.Note = adm_tasks.Note;
            this.CreatedBy = adm_tasks.CreatedBy;
            this.CreatedDate = adm_tasks.CreatedDate;
            this.ModifiedBy = adm_tasks.ModifiedBy;
            this.ModifiedDate = adm_tasks.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class ADM_TasksCollection : List<Entities.ADM_Tasks>
    {
        public ADM_TasksCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de ADM_Tasks a traves de la clase  factorys.factoryADM_Tasks
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.ADM_TasksCollection Select()
        {
            return factoryADM_Tasks.getADM_Tasks(0,string.Empty, myEnums.EntityType.EntityCollection) as Entities.ADM_TasksCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo ADM_TasksCollection con un solo registro  a traves de la clase  factorys.factoryADM_Tasks
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.ADM_TasksCollection Select(long taskID,string accountLoginUser)
        {
            return factoryADM_Tasks.getADM_Tasks(taskID,accountLoginUser, myEnums.EntityType.EntityCollection) as Entities.ADM_TasksCollection;
        }
    }
}