﻿using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.WordModel;

namespace TextProcessorLibrary.Concordance
{
    class ConcordanceWord : Word
    {
        IList<int> Lines { get; set; } // Icoll
        int Count { get; set; }
    }
}
