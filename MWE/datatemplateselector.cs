using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MWE
{
    public class datatemplateselector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return MyDataTemplate;
        }

        public DataTemplate MyDataTemplate { get; set; }
    }
}
