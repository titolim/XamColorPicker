using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamColorPicker.Core
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class XamColorPicker : Grid
	{
		#region Members
		TapGestureRecognizer tapImgColorPicker = new TapGestureRecognizer(); // Not working for UWP
		private ColorsDictionary colors = new ColorsDictionary();
		#endregion Members

		#region Properties
		public Color Color
		{
			get { return this.bvColorPicker.Color; }
			set { this.bvColorPicker.Color = value; }
		}
		#endregion Properties

		#region Constructors
		public XamColorPicker()
		{
			InitializeComponent();

			imgColorPicker.Source = ImageSource.FromResource("colors.png");

			foreach (var eachColorName in colors.Dict.Keys)
			{
				pickerColorPicker.Items.Add(eachColorName);
			}

			imgColorPicker.GestureRecognizers.Add(tapImgColorPicker);
			tapImgColorPicker.Tapped += TapImgColorPicker_Tapped;
		}
		#endregion Constructors

		#region Methods
		private void TapImgColorPicker_Tapped(object sender, EventArgs e)
		{
			pickerColorPicker.Focus();
		}

		private void PickerColorPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedColorText = pickerColorPicker.SelectedItem.ToString();
			var selectecColor = colors.Dict.First(q => q.Key == selectedColorText);

			this.Color = selectecColor.Value;
		}
		#endregion Methods
	}
}