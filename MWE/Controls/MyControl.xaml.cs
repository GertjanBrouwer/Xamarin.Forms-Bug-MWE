using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MWE.Controls
{
    public partial class MyControl : Frame
    {
        public MyControl()
        {
            InitializeComponent();
            labelname.Text = Lbl;
        }

        public string Lbl
        {
            get
            {
                return (string)GetValue(LblProperty);
            }
            set
            {
                SetValue(LblProperty, value);
            }
        }

        public static readonly BindableProperty LblProperty = BindableProperty.Create(
           nameof(Lbl),
           typeof(string),
           typeof(MyControl),
           default(string));

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == LblProperty.PropertyName)
            {
                labelname.Text = this.Lbl;
            }
        }
    }
}