using Model.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using Xceed.Wpf.AvalonDock.Controls;

namespace Model.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Является ли пользователь новым.
        /// </summary>
        public bool IsNewUser { get; set; } = false;

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

            Users = GetListItemData<User>(USER_PATH);

            CurrentUser = Users.SingleOrDefault(u => u.Firstname == firstname && u.Password == pasword);

            if (CurrentUser == null)
            {
                CurrentUser = new User(firstname, pasword);

                IsNewUser = SaveItems(Users, USER_PATH, CurrentUser);
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
                throw new ArgumentNullException(nameof(lastName), "lastName не может быть null");
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
            IsNewUser = false;
            ISave.Save(USER_PATH, Users);

        }

        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public UserController() { }


    }
}
