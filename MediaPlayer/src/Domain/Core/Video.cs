using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.src.Domain.Core
{
    public class Video : MediaFile
    {
        public Video(string fileName, string filePath, TimeSpan duration) : base(fileName, filePath, duration)
        {
            Speed = 1;
        }
    }
}