using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MWE
{
    public class datatemplatecontrol : ContentView
    {
        public DataTemplateSelector ItemTemplate
        {
            get => (DataTemplateSelector)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(datatemplatecontrol), propertyChanged: ItemTemplateChanged);

        private static void ItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as datatemplatecontrol;
            control.BuildItem();
        }

        private static void SourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as datatemplatecontrol;
            control.BuildItem();
        }

        public bool HideOnNullContent { get; set; } = false;

        protected void BuildItem()
        {
            try
            {
                Content = CreateTemplateForItem(ItemTemplate);
            }
            catch (Exception e)
            {
                //Error occurs here: read the exception
                Content = null;
            }
            finally
            {
                if (HideOnNullContent)
                    IsVisible = Content != null;
            }
        }

        public static View CreateTemplateForItem(DataTemplateSelector templateSelector)
        {
            var templateToUse = templateSelector.SelectTemplate(null, null);
            // Error occurs after calling createcontent()
            View view = (View)templateToUse.CreateContent();

            return view;
        }
    }
}
