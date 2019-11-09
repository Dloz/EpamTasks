using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Codecs.Factory
{
    class CodecFactory : ICodecFactory
    {
        public ICodec CreateCodec(string fileExtension)
        {
            switch (fileExtension)
            {
                case "mp3":
                    return new Mp3Codec();
                case "mp4":
                    return new Mp4Codec();
                default:
                    return null;
            }
        }
    }
}
