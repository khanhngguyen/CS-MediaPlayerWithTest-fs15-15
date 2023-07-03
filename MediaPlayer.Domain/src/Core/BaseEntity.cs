using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Domain.src.Core
{
    public abstract class BaseEntity
    {
        private static int _id;

        public int GetId { get; } = _id;

        public BaseEntity()
        {
            _id++;
        }
    }
}