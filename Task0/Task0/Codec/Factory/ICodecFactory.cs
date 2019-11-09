using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task0
{
    public interface ICodecFactory
    {
        ICodec CreateCodec(string fileExtension);
    }
}