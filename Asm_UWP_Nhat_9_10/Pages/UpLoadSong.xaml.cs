using Asm_UWP_Nhat_9_10.Entity;
using Asm_UWP_Nhat_9_10.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Asm_UWP_Nhat_9_10.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpLoadSong : Page
    {
        SongService songService = new SongService();
        public UpLoadSong()
        {
            this.InitializeComponent();
        }

        private void ButtonUpload_Click(object sender, RoutedEventArgs e)
        {
            Song song = new Song
            {
                name = "Chieu nay khong co mua bay",
                description = "Mua to gio lon",
                singer = "Trung Quan",
                author = "Kieu Anh",
                thumbnail = "https://www.simmonsandfletcher.com/wp-content/uploads/2013/10/siberian-1024x681.jpg",
                link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui868/ChieuNayKhongCoMuaBay-TrungQuanIdol-3314229.mp3?st=svt4XNWUlpVGX3KDe0YdjA&e=1570781399"
            };
            songService.PostSongFree(song);
        }

    }
}
