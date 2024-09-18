using Domain.Validation;
using System;

namespace Domain.Entities
{
    public class User : Base
    {
        //EF
        protected User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new System.Collections.Generic.List<string>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //Validations
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        } 

        public void ChangedEmail(string email)
        {
            Name = email;
            Validate();
        }

        public void ChangedPassword(string password)
        {
            Name = password;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidation();
            var valitation = validator.Validate(this);

            if (!valitation.IsValid) 
            {
                foreach (var error in valitation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new Exception("Alguns campos estão invalidos, por favor corrija-os!" + _errors[0]);
                
            }

            return true;
        }
    }
}
