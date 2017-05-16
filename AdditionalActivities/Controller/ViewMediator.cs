﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalActivities.Model.Persistent;
using AdditionalActivities.View.Controls.Headers;
using AdditionalActivities.View.Controls;
using AdditionalActivities.Properties;

namespace AdditionalActivities.Controller
{
    public static class ViewMediator
    {
        public static TableControl NavTable { private get; set; }
        public static TableControl DetTable { private get; set; }
        private static Stack<DatabaseObject> navStack = new Stack<DatabaseObject>();
        private static Type rootType;
        private static ActionType deleteAction;
        private static List<ActionType> actions;

        public static Type RootType
        {
            set
            {
                rootType = value;
                navStack.Clear();
                ShowRootNav();
                ShowDetails(value);
            }
        }

        public static void NavUp()
        {
            ShowDetails(navStack.Pop());
            if (navStack.Count == 0)
                ShowRootNav();
            else
                ShowNav(navStack.Peek());
        }

        public static void NavInto(DatabaseObject obj)
        {
            if (obj != null)
            {
                ShowDetails(obj);
                if (navStack.Count == 0 || obj.IsParent && navStack.Peek() != obj)
                {
                    navStack.Push(obj);
                    ShowNav(obj);
                }
            }
            else
                RootType = rootType;
        }

        private static void ShowNav(DatabaseObject parentObj)
        {
            List<DatabaseObject> objs = new List<DatabaseObject>();
            for (int i = 1; i <= 10; i++)
                objs.Add(ModelMediator.Create(typeof(ActivityPortfolio)));
            if (parentObj == null)
                ShowRootNav();
            else
                NavTable.HeaderControl = new SearchHeader(NavTable, parentObj, objs);//ModelMediator.ReadChildren(parentObj));
        }

        private static void ShowRootNav()
        {
            List<DatabaseObject> objs = new List<DatabaseObject>();
            for (int i = 1; i <= 10; i++)
                objs.Add(ModelMediator.Create(rootType));
            NavTable.HeaderControl = new SearchHeader(NavTable, rootType, objs);//ModelMediator.ReadAll(rootType));
        }

        public static void ShowDetails(DatabaseObject obj)
        {
            DetTable.HeaderControl = new DetailsHeader(DetTable, obj);
        }

        private static void ShowDetails(Type objType)
        {
            DetTable.HeaderControl = new DetailsHeader(DetTable, objType);
        }

        public static void EditDetails(DatabaseObject obj)
        {
            DetTable.HeaderControl = new DetailsEditingHeader(DetTable, obj);
        }

        public static void Save(DatabaseObject obj)
        {
            if (ModelMediator.CanSave(obj))
            {
                ShowDetails(obj);
                if (navStack.Count != 0)
                    ShowNav(navStack.Peek());
                else
                    ShowRootNav();
            }
            else
                System.Windows.Forms.MessageBox.Show(
                    Resources.ResourceManager.GetString("saveError"),
                    Resources.ResourceManager.GetString("error"),
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.None);
        }

        public static void Delete(DatabaseObject obj)
        {
            ShowDetails(obj.GetType());
            //TODO: Fix empty stack
            //ShowNav(obj == navStack.Peek() ? navStack.Pop() : navStack.Peek());
            ModelMediator.Delete(obj);
        }

        public static void Add(Type objType)
        {
            if (objType == null)
                objType = rootType;
            if (typeof(DatabaseObject).IsAssignableFrom(objType))
                EditDetails(ModelMediator.Create(objType));
        }

        public static void MultiSelect(DatabaseObject parentObj, List<DatabaseObject> childrenObjsSubSet, IHeader actualHeader)
        {
            if (childrenObjsSubSet.Count == 0)
                return;

            actions = childrenObjsSubSet.First().Actions.ToList();
            deleteAction = new ActionType(Resources.ResourceManager.GetString("delete"), null);
            actions.Add(deleteAction);

            if (parentObj != null)
                ShowDetails(parentObj.GetType());
            else
                ShowDetails(rootType);

            NavTable.HeaderControl = new MultiSelectionHeader(NavTable, parentObj, childrenObjsSubSet, actions, actualHeader);
        }

        public static void PerformMultiItemAction(DatabaseObject parentObj, List<DatabaseObject> childrenObjsSubSet, IHeader previousHeader, List<DatabaseObject> objs, ActionType action)
        {
            if (action == deleteAction)
                foreach (DatabaseObject o in objs)
                {
                    childrenObjsSubSet.Remove(o);
                    ModelMediator.Delete(o);
                }
            else
            {
                int actionIndex = actions.IndexOf(action);
                foreach (DatabaseObject o in objs)
                    o.Actions[actionIndex].Action();
            }

            MultiSelect(parentObj, childrenObjsSubSet, previousHeader);
        }

        public static void ExitMultiSelect(DatabaseObject parentObj, IHeader previousHeader)
        {
            if (previousHeader is FilterOrderHeader)
                FilterOrder(parentObj);
            else
                ShowNav(parentObj);
        }

        public static void FilterOrder(DatabaseObject parentObj)
        {
            List<DatabaseObject> children = new List<DatabaseObject>();
            if (parentObj != null)
                children = ModelMediator.ReadChildren(parentObj);
            else
                children = ModelMediator.ReadAll(rootType);
            NavTable.HeaderControl = new FilterOrderHeader(NavTable, parentObj, children);
        }
    }
}
