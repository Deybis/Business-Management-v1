using System;

namespace BusinessManagment
{
    public class myEnums
    {
        public enum SQLEngineType
        {
            MySQL,
            SQLServer
        }

        public enum Gender
        {
            Masculino = 1,
            Femenino = 2
        }

        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Create = 3,
            Delete = 4,
        }

        public enum MailType
        {
            ActivateAccountMail = 1,
            ChangePasswordMail = 2
        }

        public enum EntityType
        {
            Entity,
            EntityCollection
        }
    }
}