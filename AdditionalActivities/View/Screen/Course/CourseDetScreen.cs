﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdditionalActivities.View.Screen.Course
{
    public partial class CourseDetScreen : UserControl, IScreen
    {
        private bool isEditing;

        public bool IsEditing
        {
            get
            {
                return isEditing;
            }
            private set
            {
                isEditing = value;
                editSaveButton.Text = IsEditing ? "Salvar" : "Editar";
                splitContainer1.Panel1Collapsed = IsEditing;
                //TODO: Change fields mode
            }
        }

        public CourseDetScreen()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            MainForm.Shared().PresentScreen(new RuleDetScreen());//UNDONE: Pass object
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MainForm.Shared().PresentScreen(new RuleDetScreen());
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        public void ScreenWillApear()
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainForm.Shared().PopScreen();
        }

        private void editSaveButton_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                if (true)//UNDONE: Could save object
                    IsEditing = false;
            }
            else
                IsEditing = true;
        }
    }
}
