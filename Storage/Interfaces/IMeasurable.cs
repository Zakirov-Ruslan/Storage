using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IMeasurable
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }
        public int Size { get; }
    }
}
