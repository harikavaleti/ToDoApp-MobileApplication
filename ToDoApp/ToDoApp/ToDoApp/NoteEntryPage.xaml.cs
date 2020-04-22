using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.FileName, note.Text);

            }
            await Navigation.PopAsync();
        }

       async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
           var note = (Note)BindingContext;
            if(note == null)
            {
                return;
            }
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }
            await Navigation.PopAsync();
        }
    }
}