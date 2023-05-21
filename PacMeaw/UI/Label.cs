using SFML.Graphics;
using SFML.System;

namespace GameLib
{
    public class Label : Group
    {
        public uint fontsize { get; init; } = 100;
        public string FontName { get; init; } = "Berlin Sans FB Demi Bold.ttf";
        public Color TextColor { get; init; } = new Color(73, 95, 65);
        public Color BgColor { get; init; } = Color.White;
        public float HMargin { get; init; } = 0;
        public float VMargin { get; init; } = 0;
        public Label(string str, string fontName, uint fontsize)
        {
            this.FontName = fontName;
            this.fontsize = fontsize;
            Create(str, fontsize);
        }
        public Label(string str, uint fontsize)
        {

            Create(str, fontsize);
        }
        private void Create(string str, uint fontsize)
        {
            this.Clear();
            var font = FontCache.Get(FontName);
            var text = new TextEntity(str, font, fontsize);
            text.FillColor = TextColor;
            text.Position += new Vector2f(HMargin, VMargin);

            var rect = new RectangleEntity(
                            new Vector2f(text.TotalWidth() + 2 * HMargin, 
                                        text.TotalHeight() + 2 * VMargin));
            //rect.FillColor = BgColor;

            //this.Add(rect);
            this.Add(text);
            //DebugPositions(text);
        }

        public void SetText(string str)
        {
            
            Create(str, this.fontsize);
        }

        private void DebugPositions(TextEntity text)
        {
            float width = text.TotalWidth();
            float height = text.TotalHeight();
            float chSize = text.BaselineHeight();
            this.Add(new Cross(new Vector2f(width, 0), 5, Color.Black));
            this.Add(new Cross(new Vector2f(width, chSize), 5, Color.Red));
            this.Add(new Cross(new Vector2f(width, height), 5, Color.Blue));
        }
    }


    //var bound = text.GetLocalBounds(); // ความสูงมักไม่ได้ สำหรับ font ไทย, ความกว้างก็มักพอดีตัวเกินไป
}
