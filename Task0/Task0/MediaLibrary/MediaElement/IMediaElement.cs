using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public interface IMediaElement: IElement
    {
        string Quality { get; set; }
        string FileExtension { get; set; }
    }
}