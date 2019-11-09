using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public interface IPlayer
    {
        void Play(IEnumerable<IMediaElement> mediaElements);
        void Play(IEnumerable<IPlaylist> playlists);
    }
}