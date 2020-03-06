using System.Reflection;
using Xamarin.Forms;
using RoboScout;

[assembly: AssemblyTitle (AssemblyGlobal.ProductLine + " - " + "Grial Xamarin.Forms UIKit (Android)")]
[assembly: AssemblyConfiguration (AssemblyGlobal.Configuration)]
[assembly: AssemblyCompany (AssemblyGlobal.Company)]
[assembly: AssemblyProduct (AssemblyGlobal.ProductLine + " - " + "Grial Xamarin.Forms UIKit (Android)")]
[assembly: AssemblyCopyright (AssemblyGlobal.Copyright)]

[assembly: UXDivers.Artina.Shared.GrialVersion("2.7.1.0")]

// Custom renderer definition.

[assembly: ExportRenderer(typeof(UXDivers.Artina.Shared.CircleImage), typeof(UXDivers.Artina.Shared.ImageCircleRenderer))]
[assembly: ExportRenderer(typeof(Entry), typeof(UXDivers.Artina.Shared.ArtinaEntryRenderer))]
[assembly: ExportRenderer(typeof(Editor), typeof(UXDivers.Artina.Shared.ArtinaEditorRenderer))]
[assembly: ExportRenderer(typeof(Switch), typeof(UXDivers.Artina.Shared.ArtinaSwitchRenderer))]
[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(UXDivers.Artina.Shared.ArtinaActivityIndicatorRenderer))]
[assembly: ExportRenderer(typeof(SwitchCell), typeof(UXDivers.Artina.Shared.ArtinaSwitchCellRenderer))]
[assembly: ExportRenderer(typeof(TextCell), typeof(UXDivers.Artina.Shared.ArtinaTextCellRenderer))]
[assembly: ExportRenderer(typeof(ImageCell), typeof(UXDivers.Artina.Shared.ArtinaImageCellRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(UXDivers.Artina.Shared.ArtinaViewCellRenderer))]
[assembly: ExportRenderer(typeof(EntryCell), typeof(UXDivers.Artina.Shared.ArtinaEntryCellRenderer))]
[assembly: ExportRenderer(typeof(SearchBar), typeof(UXDivers.Artina.Shared.ArtinaSearchBarRenderer))]
[assembly: ExportRenderer(typeof(Picker), typeof(UXDivers.Artina.Shared.ArtinaPickerRenderer))]
[assembly: ExportRenderer(typeof(DatePicker), typeof(UXDivers.Artina.Shared.ArtinaDatePickerRenderer))]
[assembly: ExportRenderer(typeof(TimePicker), typeof(UXDivers.Artina.Shared.ArtinaTimePickerRenderer))]
[assembly: ExportRenderer(typeof(UXDivers.Artina.Shared.Button), typeof(UXDivers.Artina.Shared.ArtinaButtonRenderer))]


// XF 3.1+ Includes properties to control the colors of sliders that work on Android API level >= 21.
// Uncomment below renderer if you are targeting Android API <= 20 to get the Grial theme accent color applied to the Slider.
// Note that this renderer owerrides the beahvior of the Slider color properties of XF 3.1+. If you need to set a specific color
// you can use artina:SliderProperties.TintColor attached property.
//[assembly: ExportRenderer(typeof(Slider), typeof(UXDivers.Artina.Shared.ArtinaSliderRenderer))]