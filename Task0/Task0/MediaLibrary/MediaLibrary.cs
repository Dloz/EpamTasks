using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public class MediaLibrary : IMediaLibrary
    {
        public ICollection<IPlaylist> Playlists { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<IMediaElement> Elements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}