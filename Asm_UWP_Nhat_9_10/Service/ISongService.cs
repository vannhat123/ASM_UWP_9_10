using Asm_UWP_Nhat_9_10.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm_UWP_Nhat_9_10.Service
{
    interface ISongService
    {
        Song PostSongFree(Song song);

        ObservableCollection<Song> GetFreeSongs();

        ObservableCollection<Song> GetMySongs();
    }
}
