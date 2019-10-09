using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm_UWP_Nhat_9_10.Entity;

namespace Asm_UWP_Nhat_9_10.Service
{
    class SongService : ISongService
    {
        public ObservableCollection<Song> GetFreeSongs()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();


            return songs;
        }

        public Song PostSongFree(Song song)
        {

            return song;
        }
    }
}
