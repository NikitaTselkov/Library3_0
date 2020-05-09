using Model.Interfaces;
using Model.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Model.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ISave, ILoad
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
        /// Адрес User
        /// </summary>
        private const string USER_PATH = "userSave.json";

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="firstname"> Имя. </param>
        /// <param name="pasword"> Пароль. </param>
        public UserController(string firstname, string pasword)
        {
            #region Проверка Условий

            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException(nameof(firstname), "firstname не может быть null");
            }
            if (string.IsNullOrWhiteSpace(pasword))
            {
                throw new ArgumentNullException(nameof(pasword), "pasword не может быть null");
            }

            #endregion

            pasword = pasword.MyGetHashCode();

            Users = ILoad.GetUsers<List<User>>(USER_PATH);

            Users ??= new List<User>();

            CurrentUser = Users.SingleOrDefault(u => u.Firstname == firstname && u.Password == pasword);

            if(CurrentUser == null)
            {
                CurrentUser = new User(firstname, pasword);
                Users.Add(CurrentUser);
                IsNewUser = true;
                ISave.Save(USER_PATH, Users);
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
            ISave.Save(USER_PATH, Users);

        }
    }
}
