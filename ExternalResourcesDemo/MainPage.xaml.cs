using System.Text.Json;

namespace ExternalResourcesDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

     protected override async void OnAppearing()
     {
          base.OnAppearing();
          await LoadMauiAsset();
     }

     async Task LoadMauiAsset()
     {
          using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
          using var reader = new StreamReader(stream);

          var contents = reader.ReadToEnd();

          var p =
               JsonSerializer.Deserialize<Person>(contents);
     }
}

public class Person
{
     public string Name { get; set; }
     public int Age { get; set; }
}


