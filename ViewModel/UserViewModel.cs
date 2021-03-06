﻿using System;
using Model.UserFolder;
using Model.Controllers;
using ViewModel.Navigation;


namespace ViewModel
{
    public class UserViewModel : NavigateViewModel
    {

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        private string pasword;
        public string Pasword
        {
            get
            {
                if (Pasword1 != null && Pasword2 != null)
                {
                    if (Pasword1 == Pasword2)
                    {
                        return pasword = Pasword1;
                    }
                    else
                    {
                        return null;
                    }
                }
                return pasword;
            }
            set
            {
                if (Pasword1 == Pasword2 && Pasword1 != null && Pasword2 != null)
                {
                    pasword = Pasword1;
                }
                else
                {
                    pasword = value;
                }

                RaisePropertyChanged("Pasword");
            }
        }

        /// <summary>
        /// Пароль 1.
        /// </summary>
        public string Pasword1 { get; set; }

        /// <summary>
        /// Подтверждение пароля.
        /// </summary>
        public string Pasword2 { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Уровень доступа.
        /// </summary>
        public Access Access { get; set; }

        /// <summary>
        /// Создание экзeмпляра пользователя.
        /// </summary>
        private UserController user = new UserController();
        public UserController User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged("User");
            }
        }

        #region RelayCommand

        public RelayCommand Connect { get; set; }
        public RelayCommand Register { get; set; }
        public RelayCommand GoToRegister { get; set; }
        public RelayCommand SelectGender { get; set; }

        #endregion

        /// <summary>
        /// Главный конструктор.
        /// </summary>
        public UserViewModel()
        {
            Connect = new RelayCommand(ConnectMethod);
            Register = new RelayCommand(RegisterMethod);
            GoToRegister = new RelayCommand(GoToRegisterMethod);
            SelectGender = new RelayCommand(SelectGenderMethod);
        }

        #region Методы

        /// <summary>
        /// Метод подключения с проверкой на нового пользователя.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void ConnectMethod(object param)
        {
            #region Проверка Аргументов

            var isException = false;

            try
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    throw new ArgumentNullException("Имя не может быть пустым!", nameof(Name));
                }
                if (string.IsNullOrWhiteSpace(Pasword))
                {
                    throw new ArgumentNullException("Пароль не может быть пустым!", nameof(Pasword));
                }
            }
            catch (ArgumentNullException ex)
            {
                isException = true;
                NavigateWindow(WindowsEnum.Exception, ex.ParamName);
            }

            #endregion

            if (isException == false)
            {
                User = new UserController(Name, Pasword);

                if (User.IsNewUser)
                {
                    NavigateWindow(WindowsEnum.Exception, "Такого пользователя не существует!");
                }
                else
                {
                    NavigateWindow(WindowsEnum.Library);

                    NavigateCurrentUser(User.CurrentUser);
                }
            }
        }

        /// <summary>
        /// Метод регистрации с проверкой на нового пользователя.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void RegisterMethod(object param)
        {
            #region Проверка Аргументов

            var isException = false;
            try
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    throw new ArgumentNullException("Поле имя не может быть пустым!", nameof(Name));
                }               
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    throw new ArgumentNullException("Поле фамилия не может быть пустым!", nameof(LastName));
                }
                if (Age <= 0 || Age > 150)
                {
                    throw new ArgumentNullException("Укажите корректный возраст!", nameof(Age));
                }
                if (string.IsNullOrWhiteSpace(Pasword))
                {
                    throw new ArgumentNullException("Не корректный пароль!", nameof(Pasword));
                }

            }
            catch (ArgumentNullException ex)
            {
                isException = true;
                NavigateWindow(WindowsEnum.Exception, ex.ParamName);
            }

            #endregion

            if (isException == false)
            {
                CheckNameAdmins(Name);

                User = new UserController(Name, Pasword);
                if (User.IsNewUser)
                {
                    User.SetNewUserData(LastName, Age, Gender, Access);
                    NavigateWindow(WindowsEnum.Library);

                    NavigateCurrentUser(User.CurrentUser);
                }
                else
                {
                    NavigateWindow(WindowsEnum.Exception, "Такой пользователь существует!");
                }
            }
        }

        /// <summary>
        /// Метод проверки имени.
        /// </summary>
        private void CheckNameAdmins(string name)
        {
            var result = name.IndexOf(" Admin");

            if (result > 0)
            {
                Access = Access.Admin;

               Name = name.Remove(result);
            }
        }

        /// <summary>
        /// Отправляет на страницу регистрации.
        /// </summary>
        private void GoToRegisterMethod(object param)
        {
            Navigate("Pages/RegisetrUserPage.xaml");
        }

        /// <summary>
        /// Метод выбора пола.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void SelectGenderMethod(object param)
        {
            param = Convert.ToInt32(param);
            Gender = (Gender)param;
        }

        #endregion


    }
}
