using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public interface IMediaLibrary
    {
        ICollection<IPlaylist> Playlists { get; set; }
        ICollection<IMediaElement> Elements { get; set; }
    }
}