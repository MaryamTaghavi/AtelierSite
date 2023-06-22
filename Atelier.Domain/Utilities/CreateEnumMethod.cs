using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Atelier.Domain.Utilities;

namespace Atelier.Domain.Utilities
{
    public static class CreateEnumMethod
    {
        public static List<SelectListItem> GetAllEnumCombo<TBaseType>(bool hasDefaultValue = true) where TBaseType : Enum, new()
        {
            var list = new List<SelectListItem>();

            if (hasDefaultValue)
            {
                list.Add(new SelectListItem() {
                        Value = null,
                        Text = "لطفا انتخاب کنید" }
                );
            };

            Type type = typeof(TBaseType);

            list.AddRange(Enum.GetValues(type)
                .Cast<object>()
                .Select(v => new SelectListItem() { Value = ((int)v).ToString(), Text = ((TBaseType)v).ToDisplay() })
                .ToList());

            return list;
        }
    }
}
