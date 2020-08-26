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
    public class SEG_Users
    {
        public SEG_Users()
        { }

        public SEG_Users(long userID)
        {

            SEG_Users seg_users =
            (SEG_Users)factorySEG_Users.getSEG_Users(userID, myEnums.EntityType.Entity);

            if (seg_users != null)
            {
                this.UserID = seg_users.UserID;
                this.UserName = seg_users.UserName;
                this.UserLogin = seg_users.UserLogin;
                this.UserPassword = seg_users.UserPassword;
                this.UserImage = seg_users.UserImage;
                this.GenderID = seg_users.GenderID;
                this.GenderName = seg_users.GenderName;
                this.Note = seg_users.Note;
                this.CreatedBy = seg_users.CreatedBy;
                this.CreatedDate = seg_users.CreatedDate;
                this.ModifiedBy = seg_users.ModifiedBy;
                this.ModifiedDate = seg_users.ModifiedDate;

            }
        }

        [DisplayName("User")]
        [Required(ErrorMessage = "User es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public long UserID { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "User Name no debe ser mayor de 50 caracteres")]
        public string UserName { get; set; }

        [DisplayName("User Login")]
        [Required(ErrorMessage = "User Login es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "User Login no debe ser mayor de 50 caracteres")]
        public string UserLogin { get; set; }

        [DisplayName("User Password")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "User Password no debe ser mayor de 80 caracteres")]
        public string UserPassword { get; set; }

        [DisplayName("User Image")]
        [ScaffoldColumn(true)]
        public byte[] UserImage { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender es un campo obligatorio")]
        [ScaffoldColumn(true)]
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


        #region Métodos de la entidad SEG_Users


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase Factories.factorySEG_Users representado por Entities.SEG_Users como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo SEG_Users</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.SEG_Users Select(long userID)
        {
            return Factories.factorySEG_Users.getSEG_Users(userID, myEnums.EntityType.Entity) as Entities.SEG_Users;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase Factories.factorySEG_Users persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(SEG_Users seg_users)
        {
            return Factories.factorySEG_Users.saveSEG_Users(seg_users);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase Factories.factorySEG_Users persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(SEG_Users seg_users)
        {
            return Factories.factorySEG_Users.saveSEG_Users(seg_users);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase Factories.factorySEG_Users
        /// </summary>
        /// <param name="seg_users"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(SEG_Users seg_users)
        {
            return Factories.factorySEG_Users.deteleSEG_Users(seg_users.UserID);
        }

        /// <summary>
        /// Devuelve el Objeto SEG_Users a una cadena formateada XML
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
            SEG_Users seg_users = (SEG_Users)obj;

            this.UserID = seg_users.UserID;
            this.UserName = seg_users.UserName;
            this.UserLogin = seg_users.UserLogin;
            this.UserPassword = seg_users.UserPassword;
            this.UserImage = seg_users.UserImage;
            this.GenderID = seg_users.GenderID;
            this.GenderName = seg_users.GenderName;
            this.Note = seg_users.Note;
            this.CreatedBy = seg_users.CreatedBy;
            this.CreatedDate = seg_users.CreatedDate;
            this.ModifiedBy = seg_users.ModifiedBy;
            this.ModifiedDate = seg_users.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class SEG_UsersCollection : List<Entities.SEG_Users>
    {
        public SEG_UsersCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de SEG_Users a traves de la clase  Factories.factorySEG_Users
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.SEG_UsersCollection Select()
        {
            return Factories.factorySEG_Users.getSEG_Users(0, myEnums.EntityType.EntityCollection) as Entities.SEG_UsersCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo SEG_UsersCollection con un solo registro  a traves de la clase  Factories.factorySEG_Users
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.SEG_UsersCollection Select(long userID)
        {
            return Factories.factorySEG_Users.getSEG_Users(userID, myEnums.EntityType.EntityCollection) as Entities.SEG_UsersCollection;
        }
    }
}