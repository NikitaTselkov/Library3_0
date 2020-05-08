using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

namespace Model.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Является ли пользователь новым.
        /// </summary>
        public bool IsNewUser { get; } = false;


        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="firstname"> Имя. </param>
        /// <param name="pasword"> Пароль. </param>
        public UserController(string firstname, string pasword)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException(nameof(firstname), "firstname не может быть null");
            }
            if (string.IsNullOrWhiteSpace(pasword))
            {
                throw new ArgumentNullException(nameof(pasword), "pasword не может быть null");
            }

            pasword = pasword.MyGetHashCode();

            Users = GetUsers();

            CurrentUser = Users.SingleOrDefault(u => u.Firstname == firstname && u.Password == pasword);

            if(CurrentUser == null)
            {
                CurrentUser = new User(firstname, pasword);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        /// <summary>
        ///  Задает пользователю не достающии данные.
        /// </summary>
        /// <param name="lastName"> Фамилия. </param>
        /// <param name="age"> Возраст. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="access"> Уровень доступа. </param>
        public void SetNewUserData(string lastName, int age, Gender gender, Access access)
        {
            #region Проверка Условий

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "firstname не может быть null");
            }
            if (age <= 0 || age > 150)
            {
                throw new ArgumentException(nameof(age), "Не корректное значение age");
            }

            #endregion

            CurrentUser.Lastname = lastName;
            CurrentUser.Age = age;
            CurrentUser.Gender = gender;
            CurrentUser.Access = access;
            Save();

        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>    
        public void Save()
        {
            var formatter = new DataContractJsonSerializer(typeof(List<User>));

            using (var fs = new FileStream("userSave.json", FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, Users);
            }
        }

        /// <summary>
        /// Загрузить данные пользователя.
        /// </summary>
        /// <returns> Пользователи. </returns>
        private List<User> GetUsers()
        {
            var formatter = new DataContractJsonSerializer(typeof(List<User>));


            using (var fs = new FileStream("userSave.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    if (formatter.ReadObject(fs) is List<User> users)
                    {
                        return users;
                    }
                    else
                    {
                        return new List<User>();
                    }
                }
                return new List<User>();
            }

        }
    }
}
