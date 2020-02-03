using System;
using System.Collections.Generic;

namespace Capstone2_TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            //list for menu access

            List<string> menuOptions = new List<string>
            { 
                "List of Assigned Tasks",
                "Assign Addtional Task",
                "Remove Assigned Task",
                "Mark Assigned Task Complete",
                "End Session",
            };


            List<TaskClass> taskList= new List<TaskClass>
            {
                //list of strings with name task
                new TaskClass("Sean","Complete your Capstone 2 Project", DateTime.Parse("3/22/19")),
                new TaskClass("Blake","2 hours of research on string arrays ", DateTime.Parse("3/22/19")),
                new TaskClass ("James","Activate a Bird Scooter", DateTime.Parse("3/22/19")),
            };

            Console.WriteLine("Welcome to the C# Task Manager, please choose from the options below.");

            //  Console.WriteLine()

           

            bool loopAgain = true;
            do
            {

                //Access PrintMenu method to print menuOptions string
                PrintMenu(menuOptions);
                int userSelection = ValidateMenuInput(menuOptions, Console.ReadLine());
                if (userSelection == 0)
                {
                    PrintTaskList(taskList);
                }
                else if (userSelection == 1)
                {
                    AddToTaskList(taskList);
                }
                else if (userSelection == 2)
                {
                    DeleteTaskFromList(taskList);
                }
                else if (userSelection == 3)
                {
                    MarkTaskComplete(taskList);
                }
                
                
            }
            while (loopAgain == true);
            



        }

        //grab user input!
        public static string GetUserInput (string message)
        {
            Console.WriteLine(message);
            string selection = Console.ReadLine();
            return selection;
        }
        
        // ask if they would like to continue.
        public static bool AnotherChoice(string message, string choice1, string choice2)
        {
            string userContinue = "";
            while(userContinue != choice1 && userContinue != choice2)
            {
                Console.WriteLine(message);
                userContinue = Console.ReadLine();
                if(userContinue == choice2)
                {
                    Console.WriteLine("Good day sir");
                    return false;

                }
            }
            return true;

        }

        //Print Menu Method
        public static void PrintMenu(List<string> menuItem)
        {
            for(int i = 0; i <menuItem.Count; i++)
            {
                Console.WriteLine($"{i+1}. {menuItem[i]} ");
                //lists menu with numbers 1. 2. 3. etc
            }
            Console.WriteLine();
        }
        //print TaskList
        public static void PrintTaskList(List<TaskClass> taskList)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {taskList[i].TaskOwnerName}\t Due on:{taskList[i].Due}\t{taskList[i].Complete}\t Description:{taskList[i].Description}");
                //lists menu with numbers 1. 2. 3. etc
            }

        }



        //Validate int input by user for menuoptions
        public static int ValidateMenuInput(List<string> inputOptions, string menuChoice)
        {
            try
            { // takes number entered -1 to line up with menu options
                int choice = int.Parse(menuChoice) - 1;
                string tryEntry = inputOptions[choice];
                return choice;
            }
            catch
            {
                return ValidateMenuInput(inputOptions, GetUserInput($"Sorry, but that is not a option!"));
            }
        }
        public static int ValidateTaskInput(List<TaskClass> inputOptions, string taskChoice)
        {
            try
            { // takes number entered -1 to line up with menu options
                int choice = int.Parse(taskChoice) - 1;
                string tryEntry = inputOptions[choice].TaskOwnerName;
                return choice;
            }
            catch
            {
                return ValidateTaskInput(inputOptions, GetUserInput($"Sorry, but that is not a option!"));
            }
        }

        //Add
        public static void AddToTaskList(List<TaskClass> addTask)
        {
            string name = GetUserInput("Assign a new task to who?");
            string description = GetUserInput("Please describe the new task.");
            DateTime due = DateTime.Parse("11/11/1111");

            bool validateDate = true;
            while (validateDate == true)
            {
                try
                {
                    due = DateTime.Parse(GetUserInput("When will the task be due?(mm/dd/yyy)"));
                    validateDate = false;
                    
                }
                catch
                {
                    Console.WriteLine("Please enter a valid due date. mm/dd/yyyy");
                    validateDate = true;
                }
             
            }
            Console.WriteLine();
            addTask.Add(new TaskClass( name, description, due));
        }


        //Delete a task
        public static void DeleteTaskFromList (List<TaskClass> deleteATask)
        {
            PrintTaskList(deleteATask);

            int num = ValidateTaskInput(deleteATask, GetUserInput("Which task would you like to mark complete."));
           
            Console.WriteLine($"{num + 1}. {deleteATask[num].TaskOwnerName},\tDue Date: {deleteATask[num].Due.ToShortDateString()}  \tCompleted: {deleteATask[num].Complete} \tDescription: {deleteATask[num].Description}\n");

            bool goAgain = AnotherChoice("Are you sure you want to delete the task, y/n ?", "Y", "N");
            if (goAgain == true)
            {
                deleteATask.RemoveAt(num);
            }
                             
                
        }

        // Mark are complete
        public static void MarkTaskComplete(List<TaskClass> markedComplete)
        {
            PrintTaskList(markedComplete);
            int num = ValidateTaskInput(markedComplete, GetUserInput("Which task would you like to mark complete."));
            Console.WriteLine($"{num + 1}. {markedComplete[num].TaskOwnerName},\tDue Date: {markedComplete[num].Due.ToShortDateString()}  \tCompleted: {markedComplete[num].Complete} \tDescription: {markedComplete[num].Description}\n");
            
            bool goAgain = AnotherChoice("Are you sure you want to delete the task, y/n ?", "Y", "N");
            if (goAgain == true)
            {
                markedComplete[num].Complete = true;
            }

        }



    }
}
