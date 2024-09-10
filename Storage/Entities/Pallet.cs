using Storage.Interfaces;

namespace Storage.Entities
{
    public class Pallet : IMeasurable, IWeighty
    {
        private long _id;
        private int _width;
        private int _height;
        private int _depth;
        private List<Box> _boxes;

        public long Id { get => _id; }
        public int Width { get => _width; }
        public int Height { get => _height; }
        public int Depth { get => _depth; }
        public int Weight { get => _boxes.Sum(box => box.Weight) + 30; }
        public List<Box> Boxes { get => _boxes; }
        public int Size { get => _boxes.Sum(box => box.Size) + _height * _width * _depth; }
        public DateTime ExpirationDate { get => _boxes.Min(box => box.ExpirationDate.Date); }

        public Pallet(long id, int width, int height, int depth, List<Box> boxes)
        {
            if (boxes.Any(box => box.Width > width || box.Depth > depth))
                throw new ArgumentException("Width and depth of the box cant be bigger than pallet");

            _id = id;
            _width = width;
            _height = height;
            _depth = depth;
            _boxes = boxes;
        }

        public override string ToString()
        {
            return $"Pallet ID: {Id.ToString().PadLeft(3)}, Size: {Size}, Weight: {Weight.ToString().PadLeft(3)}, Boxes Count: {Boxes.Count}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }

    }
}
