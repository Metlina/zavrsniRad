using System.Collections.Generic;
using ZavrsniRad.Model.Model;

namespace ZavrsniRad.Model.Data
{
    public class QuizData
    {
        public List<Question> EasyQuestions = new List<Question>();
        public List<Question> MediumQuestions = new List<Question>();
        public List<Question> HardQuestions = new List<Question>();

        public QuizData()
        {
            InitializeData();
        }

        void InitializeData()
        {
            var questionEasy1 = new Question
            {
                Id = 1,
                Text = "How many page controls are in Xamarin.Forms?",
                FirstAnswer = "5",
                SecondAnswer = "4",
                ThirdAnswer = "3",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            var questionEasy2 = new Question
            {
                Id = 2,
                Text = "Screens are crated in Xamarin.Froms throught the _____ class",
                FirstAnswer = "View",
                SecondAnswer = "Page",
                ThirdAnswer = "Screen",
                CorrectAnswer = 2,
                Category = Category.Easy
            };

            var questionEasy3 = new Question
            {
                Id = 3,
                Text = "What control is part of Xamarin Forms controls?",
                FirstAnswer = "Textblock",
                SecondAnswer = "StackPanel",
                ThirdAnswer = "Switch",
                CorrectAnswer = 3,
                Category = Category.Easy
            };

            var questionEasy4 = new Question
            {
                Id = 4,
                Text = "Which Xamarin.Forms Page type is used for stack-based navigation?",
                FirstAnswer = "NavigationPage",
                SecondAnswer = "TabbedPage",
                ThirdAnswer = "MasterDetail",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            var questionEasy5 = new Question
            {
                Id = 5,
                Text = "Which pattern was invented at Microsoft to make data binding with XAML easier?",
                FirstAnswer = "MVC",
                SecondAnswer = "MVVM",
                ThirdAnswer = "PCL",
                CorrectAnswer = 2,
                Category = Category.Easy
            };

            EasyQuestions.Add(questionEasy1);
            EasyQuestions.Add(questionEasy2);
            EasyQuestions.Add(questionEasy3);
            EasyQuestions.Add(questionEasy4);
            EasyQuestions.Add(questionEasy5);

            var questionMedium1 = new Question
            {
                Id = 1,
                Text = "The _____ pattern allows a user to hierachically drill down through screens",
                FirstAnswer = "Singleton",
                SecondAnswer = "Tab",
                ThirdAnswer = "Stack",
                CorrectAnswer = 3,
                Category = Category.Medium
            };

            var questionMedium2 = new Question
            {
                Id = 2,
                Text = "What class is the starting point of every iOS application?",
                FirstAnswer = "Main",
                SecondAnswer = "AppDelegate",
                ThirdAnswer = "MainActivity",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            var questionMedium3 = new Question
            {
                Id = 3,
                Text = "Which resources cannot be implemented in shared project?",
                FirstAnswer = "ControlTemplate",
                SecondAnswer = "Colors",
                ThirdAnswer = "Images",
                CorrectAnswer = 3,
                Category = Category.Medium
            };

            var questionMedium4 = new Question
            {
                Id = 4,
                Text = "XAML View is made of ________",
                FirstAnswer = ".xaml.cs file and .cs file",
                SecondAnswer = ".xaml file and cs file",
                ThirdAnswer = ".xaml and xaml.cs file",
                CorrectAnswer = 3,
                Category = Category.Medium
            };

            var questionMedium5 = new Question
            {
                Id = 5,
                Text = "Messenger class is part of what library?",
                FirstAnswer = "MVVM light",
                SecondAnswer = "PrismMVVM",
                ThirdAnswer = "MVVMCross",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            MediumQuestions.Add(questionMedium1);
            MediumQuestions.Add(questionMedium2);
            MediumQuestions.Add(questionMedium3);
            MediumQuestions.Add(questionMedium4);
            MediumQuestions.Add(questionMedium5);

            var questionHard1 = new Question
            {
                Id = 1,
                Text = "What pattern do we often use with Portable Class Librarires to allow platform specific code to be executed",
                FirstAnswer = "Model-View-ViewModel",
                SecondAnswer = "Singleton",
                ThirdAnswer = "Dependency Injection",
                CorrectAnswer = 3,
                Category = Category.Hard
            };

            var questionHard2 = new Question
            {
                Id = 2,
                Text = "Xamarin for Android compilation uses which type of compilation",
                FirstAnswer = "JIT",
                SecondAnswer = "AOT",
                ThirdAnswer = "C# Intpreter",
                CorrectAnswer = 1,
                Category = Category.Hard
            };

            var questionHard3 = new Question
            {
                Id = 3,
                Text = "Many of the iOS specific application properties are stored in the?",
                FirstAnswer = "AssemblyInfo.cs",
                SecondAnswer = "Inflo.plist",
                ThirdAnswer = "iOSSettings.xml",
                CorrectAnswer = 2,
                Category = Category.Hard
            };

            var questionHard4 = new Question
            {
                Id = 4,
                Text = "In what language does XAML compile when we implement XAMLC?",
                FirstAnswer = "C#",
                SecondAnswer = "Assembly",
                ThirdAnswer = "IL",
                CorrectAnswer = 3,
                Category = Category.Hard
            };

            var questionHard5 = new Question
            {
                Id = 5,
                Text = "What class do we use for platform specific code?",
                FirstAnswer = "Platform",
                SecondAnswer = "Device",
                ThirdAnswer = "Idiom",
                CorrectAnswer = 2,
                Category = Category.Hard
            };

            HardQuestions.Add(questionHard1);
            HardQuestions.Add(questionHard2);
            HardQuestions.Add(questionHard3);
            HardQuestions.Add(questionHard4);
            HardQuestions.Add(questionHard5);
        }
    }
}

