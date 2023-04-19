namespace TrapeInvaders
{
    public sealed class Transform
    {
        public int Id { get; }

        private Rect _Rect;
        public Rect Rect { get => _Rect; set => _Rect = value; }
        public Vec2 Pos { get => _Rect.Pos; set => _Rect.Pos = value; }
        public Vec2 Size 
        { 
            get => _Rect.Size;
            set 
            {
                Assert.Positive(value);

                _Rect.Size = value;
            } 
        }

        private static int _Count;
        public static int Count => _Count++;

        public Transform(Vec2 pos, Vec2 size)
        {
            Id = Count;
            _Rect = new Rect(pos, size);
        }
    }
}
