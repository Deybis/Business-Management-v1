
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BusinessManagment.Entities
{
    [DataObject]
    [Serializable]
    public class FileModel
    {
        public FileModel()
        { }

        [DisplayName("LastModified")]
        [Required(ErrorMessage = "LastModified es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public string LastModified { get; set; }

        [DisplayName("LastModifiedDate")]
        [Required(ErrorMessage = "LastModifiedDate es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public string LastModifiedDate { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public string Name { get; set; }

        [DisplayName("Size")]
        [Required(ErrorMessage = "Size es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int Size { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "Type es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public string Type { get; set; }

        [DisplayName("WebkitRelativePath")]
        [Required(ErrorMessage = "WebkitRelativePath es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public string WebkitRelativePath { get; set; }

        [ScaffoldColumn(true)]
        public IFormFile File { get; set; }


        private void InitializeComponent(Object obj)
        {
            FileModel adm_file = (FileModel)obj;

            this.LastModified = adm_file.LastModified;
            this.LastModifiedDate = adm_file.LastModifiedDate;
            this.Name = adm_file.Name;
            this.Size = adm_file.Size;
            this.Type = adm_file.Type;
            this.WebkitRelativePath = adm_file.WebkitRelativePath;

        }
    }
    [DataObject]
    [Serializable]
    public class FileModelColection : List<FileModel>
    {
       public FileModelColection()
       {}
    }
}