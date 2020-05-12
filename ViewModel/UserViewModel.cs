using System;
using Model.UserFolder;
using Model.Controllers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.Navigation;
using GalaSoft.MvvmLight.Command;
using Model.Interfaces;
using Microsoft.Windows.Shell;

namespace ViewModel
{
    public class UserViewModel : NavigateViewModel , INotifyPropertyChanged
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

                OnPropertyChanged("Pasword");
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
            User = new UserController(Name, Pasword);

            if (User.IsNewUser)
            {
                NavigateWindow(Windows.Exception, "Ops");
                //TODO: Отправлять сообщение об ошибке такого пользователя нет.
            }
            else
            {
                NavigateWindow(Windows.Library);
                //TODO: Реализовать вход в систему.
                
            }
        }

        /// <summary>
        /// Метод регистрации с проверкой на нового пользователя.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void RegisterMethod(object param)
        {
            if (Pasword != null)
            {
                User = new UserController(Name, Pasword);
                if (User.IsNewUser)
                {
                    User.SetNewUserData(LastName, Age, Gender, Access);
                    Console.WriteLine(User.IsNewUser);
                }
                else
                {
                    //TODO: отправлять сообщение об ошибке Такой пользователь есть. 
                }
            }
            else
            {
                //TODO: отправлять сообщение об ошибке не правельный пароль.            
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
                OnPropertyChanged("User");
            }
        }


        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
