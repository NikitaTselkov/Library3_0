using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class User
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DataMember]
        public string Lastname { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        [DataMember]
        public int Age { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        [DataMember]
        public Gender Gender { get; set; }

        /// <summary>
        /// Уровень Доступа.
        /// </summary>
        [DataMember]
        public Access Access { get; set; }

        [DataMember]
        public string Password { get; set; }


        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="firstname"> Имя. </param>
        /// <param name="lastname"> Фамилия. </param>
        /// <param name="age"> Возраст. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="access"> Уровень доступа. </param>
        public User(string firstname, string lastname, int age, Gender gender, Access access)
        {
            #region Проверка Условий

            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException(nameof(firstname), "firstname не может быть null");
            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException(nameof(lastname), "lastname не может быть null");
            }
            if (age <= 0 || age > 150)
            {
                throw new ArgumentException(nameof(age), "Не корректное значение age");
            }

            #endregion

            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Gender = gender;
            Access = access;
        }

        /// <summary>
        /// Создание Текущего пользователя.
        /// </summary>
        /// <param name="firstname"> Имя. </param>
        /// <param name="pasword"> Пароль. </param>
        public User(string firstname, string pasword)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException(nameof(firstname), "firstname не может быть null");
            }
            if (string.IsNullOrWhiteSpace(pasword))
            {
                throw new ArgumentNullException(nameof(pasword), "pasword не может быть null");
            }

            Password = pasword;

            Firstname = firstname;
        }


        public override string ToString()
        {
            return string.Format("Name: {0}, LastName: {1}, Age: {2}, Gender: {3}, Access: {4}", Firstname, Lastname, Age, Gender, Access).ToString();
        }

    }
}
