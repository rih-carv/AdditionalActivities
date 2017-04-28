﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalActivities.Model
{
    class Activity
    {
        private string name, description, observation, certificate;
        private int id, minHours, maxHours, hourStep;
        private ActivityCategory category;

        public Activity(string name, string certificate, int minHours, int maxHours, ActivityCategory category)
        {
            this.Name = name;
            this.Certificate = certificate;
            //this.Id =
            this.MinHours = minHours;
            this.MaxHours = maxHours;
            this.HourStep = 1;
            this.Category = category;
        }

        public Activity(string name, string description, string observation, string certificate, int minHours, int maxHours, int hourStep, ActivityCategory category)
        {
            this.Name = name;
            this.Description = description;
            this.Observation = observation;
            this.Certificate = certificate;
            //this.Id =
            this.MinHours = minHours;
            this.MaxHours = maxHours;
            this.HourStep = hourStep;
            this.Category = category;
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Observation
        {
            get
            {
                return observation;
            }

            set
            {
                observation = value;
            }
        }

        public string Certificate
        {
            get
            {
                return certificate;
            }

            set
            {
                certificate = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int MinHours
        {
            get
            {
                return minHours;
            }

            set
            {
                minHours = value;
            }
        }

        public int MaxHours
        {
            get
            {
                return maxHours;
            }

            set
            {
                maxHours = value;
            }
        }

        public int HourStep
        {
            get
            {
                return hourStep;
            }

            set
            {
                hourStep = value;
            }
        }

        internal ActivityCategory Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }
    }
}