using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2_TaskList
{
    class TaskClass
    {
        //Fields
        private string name;
        private string description;
        private DateTime due;
        private bool complete;

        //Properties
        public string TaskOwnerName
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime Due
        {
            get { return due; }
            set { due = value; }
        }

        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }

        //Constructors

        //default
        public TaskClass()
        {

        }
        public TaskClass(string _name, string _description, DateTime _due, bool complete = false)
        {
            TaskOwnerName = _name;
            Description = _description;
            Due = _due;
            Complete = complete;
            
        }

        

     

    }
}
