using ViewModel;
using System;
using Model.Controllers;
using Model.BookFolder;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    class Tset
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Name");
            //var Name = Console.ReadLine();

            //Console.WriteLine("Pasword");
            //var Pasword = Console.ReadLine();

            //var User = new UserController(Name, Pasword);

            //if (User.IsNewUser)
            //{
            //    Console.WriteLine("LastName");
            //    var LastName = Console.ReadLine();

            //    Console.WriteLine("Age");
            //    var Age = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Gender");
            //    Gender Gender = (Gender)Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Access");
            //    Access Access = (Access)Convert.ToInt32(Console.ReadLine());

            //    User.SetNewUserData(LastName, Age, Gender, Access);
            //}

            //Console.WriteLine(User.CurrentUser);

            Console.WriteLine("Введите заголовок");
            var Title = Console.ReadLine();

            var book = new BookController(Title);

            if (book.IsNewBook)
            {

                Console.WriteLine("Введите Code");
                var Code = Console.ReadLine();

                Console.WriteLine("Введите Using");
                var Using = Console.ReadLine();

                Console.WriteLine("Введите Template");
                var Template = Console.ReadLine();

                Console.WriteLine("Введите Definition Title");
                var TitleDefinition = Console.ReadLine();
                Console.WriteLine("Введите Definition Definition");
                var DefinitionDefinition = Console.ReadLine();

                var Definition = new List<ListDefinition>
                {
                    new ListDefinition(TitleDefinition, DefinitionDefinition)
                };

                Console.WriteLine("Введите Property Title");
                var TitleProperty = Console.ReadLine();
                Console.WriteLine("Введите Property Definition");
                var DefinitionProperty = Console.ReadLine();

                var Property = new List<ListDefinition>
                {
                    new ListDefinition(TitleProperty, DefinitionProperty)
                };

                Console.WriteLine("Введите Return Title");
                var TitleReturn = Console.ReadLine();
                Console.WriteLine("Введите Return Definition");
                var DefinitionReturn = Console.ReadLine();

                var Return = new List<ListDefinition>
                {
                    new ListDefinition(TitleReturn, DefinitionReturn)
                };


                book.SetNewBookData(Code, Using, Template, Definition, Property, Return);
            }


            Console.WriteLine(book.CurrentBook);

            for (int i = 0; i < book.CurrentBook.Definition.Count(); i++)
            {
                Console.WriteLine(book.CurrentBook.Definition.ElementAt(i).Title + " " + book.CurrentBook.Definition.ElementAt(i).Definition);
                Console.WriteLine(book.CurrentBook.Propertie.ElementAt(i).Title + " " + book.CurrentBook.Propertie.ElementAt(i).Definition);
                Console.WriteLine(book.CurrentBook.Return.ElementAt(i).Title + " " + book.CurrentBook.Return.ElementAt(i).Definition);
            }

        }

    }
}

