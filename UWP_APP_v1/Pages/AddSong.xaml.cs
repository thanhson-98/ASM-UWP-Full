using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWP_APP_v1.Entity;
using UWP_APP_v1.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_APP_v1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSong : Page
    {
        private SongService songService;
        private static string token = null;

        public AddSong()
        {
            this.InitializeComponent();
            songService = new SongServiceImp();
        }

        private void AddSongButton(object sender, RoutedEventArgs e)
        {
            var song = new Song
            {
                name = this.name.Text,
                author = this.Author.Text,
                singer = this.Singer.Text,
                description = this.Description.Text,
                thumbnail = this.Thumbnail.Text,
                link = this.Link.Text,
            };
            //songService.PostSongFreeAsync(song);
            //show success
            MessageDialog messageDialog = new MessageDialog("Post the song successfully, thank you");
            _ = messageDialog.ShowAsync();

            //validate
            Dictionary<String, String> errors = song.Validate();
            if (errors.Count == 0)
            {
                songService.PostSongFreeAsync(song);

            }
            else
            {
                if (errors.ContainsKey("name") || errors.ContainsKey("Singer") || 
                    errors.ContainsKey("Description") || errors.ContainsKey("Author") || 
                    errors.ContainsKey("Thumbnail") || errors.ContainsKey("Link"))
                {
                    NameMessage.Text = errors["name"];
                    NameMessage.Visibility = Visibility.Visible;
                    SingerMessage.Text = errors["Singer"];
                    SingerMessage.Visibility = Visibility.Visible;
                    DescriptionMessage.Text = errors["Description"];
                    DescriptionMessage.Visibility = Visibility.Visible;
                    AuthorMessage.Text = errors["Author"];
                    AuthorMessage.Visibility = Visibility.Visible;
                    ThumbnailMessage.Text = errors["Thumbnail"];
                    ThumbnailMessage.Visibility = Visibility.Visible;
                    LinkMessage.Text = errors["Link"];
                    LinkMessage.Visibility = Visibility.Visible;
                }
                else
                {                
                    NameMessage.Visibility = Visibility.Collapsed;
                    SingerMessage.Visibility = Visibility.Collapsed;
                    DescriptionMessage.Visibility = Visibility.Collapsed;
                    AuthorMessage.Visibility = Visibility.Collapsed;
                    ThumbnailMessage.Visibility = Visibility.Collapsed;
                    LinkMessage.Visibility = Visibility.Collapsed;
                }
                // pop up error message
            }
        }    
    }
}
