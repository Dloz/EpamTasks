using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public class Playlist : IPlaylist
    {
        public ICollection<IMediaElement> Elements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}