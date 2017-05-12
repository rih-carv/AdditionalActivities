﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalActivities.Model.Persistent
{
    public interface IPersistentObjectModel
    {
        PersistentObjectModelType GetObjectModelType();
        List<FieldModel> GetFields(bool editingMode);
        void SetValueWithField(FieldModel field);
        //List<IPersistentObjectModel> ReadChildren();
        string GetTitle();
        string GetSubtitle();
        bool IsParent();
        bool ShouldSave();
    }
}
