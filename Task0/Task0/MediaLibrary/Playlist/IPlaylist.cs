using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public interface IPlaylist: IElement
    {
        ICollection<IMediaElement> Elements { get; set; }
    }
}