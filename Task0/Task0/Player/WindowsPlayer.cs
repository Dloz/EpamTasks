using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task0.Codecs.Factory;

namespace Task0.MediaLibrary.Players
{
    class WindowsPlayer : IPlayer
    {
        public void Play(IEnumerable<IMediaElement> mediaElements)
        {
            foreach (var element in mediaElements)
            {
                new CodecFactory().CreateCodec(element.FileExtension).Process(element);
            }
        }

        public void Play(IEnumerable<IPlaylist> playlists)
        {
            foreach (var playlist in playlists)
            {
                Play(playlist.Elements.AsEnumerable());
            }
        }
    }
}
