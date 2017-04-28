﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalActivities.Model
{
    class Rule
    {
        private string name, course;
        private int year, hours;
        private List<ActivityCategory> categories;

        public Rule(string name, string course, int year, int hours)
        {
            this.Name = name;
            this.Course = course;
            this.Year = year;
            this.Hours = hours;
            this.categories = new List<ActivityCategory>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Course
        {
            get
            {
                return course;
            }

            set
            {
                course = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public int Hours
        {
            get
            {
                return hours;
            }

            set
            {
                hours = value;
            }
        }

        internal List<ActivityCategory> Categories
        {
            get
            {
                return categories;
            }

            set
            {
                categories = value;
            }
        }

        public void AddCategory(ActivityCategory category)
        {
            this.Categories.Add(category);
        }

        public void RemoveCategory(ActivityCategory category)
        {
            this.Categories.Remove(category);
        }

        public ActivityCategory GetCategory(int index)
        {
            return this.Categories[index];
        }

        public void SetCategory(int index, ActivityCategory category)
        {
            this.Categories[index] = category;
        }
    }
}