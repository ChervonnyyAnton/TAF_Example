using System;
using Newtonsoft.Json;

namespace DataProvider.Backend.DataObjects
{
    public enum UserType
    {
        Default,
        Invalid
    }

    public class User
    {
        [JsonProperty("firstName")]
        string? FirstName { get; set; }
        [JsonProperty("login")]
        string? Login { get; set; }
        [JsonProperty("password")]
        string? Password { get; set; }

        public User()
        {
            SetupDefaultUser(UserType.Default);
        }

        private User SetupDefaultUser(UserType type)
        {
            switch (type)
            {
                case UserType.Default:
                    return CreateDefaultUser();
                case UserType.Invalid:
                    return CreateInvalidUser();
                default:
                    return this;
            }
        }

        private User CreateInvalidUser()
        {
            return CreateUserManual("Иван", "Ivan", "Ivan12345");
        }

        private User CreateDefaultUser()
        {
            return CreateUserManual("Иван", "Ivan", null);
        }

        public User CreateUserManual(string? firstName, string? login, string? password)
        {
            this.FirstName = firstName;
            this.Login = login;
            this.Password = password;

            return this;
        }
    }
}