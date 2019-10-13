using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_APP_v1.Entity;

namespace UWP_APP_v1.Service
{
    interface SongService
    {      
        Song PostSongFreeAsync(Song song);
        ObservableCollection<Song> GetFreeSong();
    }
}
