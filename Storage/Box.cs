namespace Storage
{
    public class Box
    {
        private long _id;
        private int _width;
        private int _height;
        private int _depth;
        private int _weight;

        private DateTime? _productionDate;
        private DateTime? _expirationDate;


        public long Id { get => _id; }
        public int Weight { get => _weight;  }
        public int Width { get => _width; }
        public int Height { get => _height; }
        public int Depth { get => _depth; }
        public int Size { get => Height * Width * Depth; }
        public DateTime? ProductionDate { get => _productionDate.Value.Date; }
        public DateTime ExpirationDate { get => _expirationDate?.Date ?? (_productionDate + TimeSpan.FromDays(100)).Value.Date; }

        public Box(long id, int width, int height, int depth, int weight, DateTime? productionDate = null, DateTime? expirationDate = null)
        {
            if (width <= 0 || height <= 0 || depth <= 0 || weight <= 0)
                throw new ArgumentOutOfRangeException();
            if (productionDate == null && expirationDate == null)
                throw new ArgumentNullException("One of Production Date or Expiration Date must be not null");

            _id = id;
            _width = width;
            _height = height;
            _depth = depth;
            _weight = weight;
            _productionDate = productionDate;
            _expirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"Box ID: {_id}, Size: {Size}, Weight: {Weight}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }
    }
}