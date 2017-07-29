namespace CaptchaGenerator
{

    using System.Drawing;

    public sealed class CaptchaProperties
    {
        private readonly CaptchaPropertiesFluentInterface _configure;
        public CaptchaPropertiesFluentInterface Configure => _configure;


        private readonly Color _default_background_color = Color.White;
        public Color BackgroundColor { get; private set; }

        private readonly int _default_characters = 5;
        public int Characters { get; private set; }

        private readonly Color _default_color_down_up_line = Color.Black;
        public Color ColorDownUpLine { get; private set; }

        private readonly Color _default_color_up_down_line = Color.Black;
        public Color ColorUpDownLine { get; private set; }

        private readonly bool _default_draw_down_up_line = false;
        public bool DrawDownUpLine { get; private set; }

        private readonly bool _default_draw_up_down_line = false;
        public bool DrawUpDownLine { get; private set; }

        private readonly Color _default_font_color = Color.Black;
        public Color FontColor { get; private set; }

        private readonly RandomCharactersType _default_random_characters = RandomCharactersType.All;
        public RandomCharactersType RandomCharacters { get; private set; }

        private readonly int _default_size_down_up_line = 2;
        public int SizeDownUpLine { get; private set; }

        private readonly int _default_size_up_down_line = 2;
        public int SizeUpDownLine { get; private set; }

        private readonly Font _default_font = new Font("Tahoma", 24);
        public Font StringFont { get; private set; }


        public CaptchaProperties()
        {
            _configure = new CaptchaPropertiesFluentInterface(this);

            BackgroundColor = _default_background_color;
            Characters = _default_characters;
            ColorDownUpLine = _default_color_down_up_line;
            ColorUpDownLine = _default_color_up_down_line;
            DrawDownUpLine = _default_draw_down_up_line;
            DrawUpDownLine = _default_draw_up_down_line;
            FontColor = _default_font_color;
            RandomCharacters = _default_random_characters;
            SizeDownUpLine = _default_size_down_up_line;
            SizeUpDownLine = _default_size_up_down_line;
            StringFont = _default_font;
        }

        public class CaptchaPropertiesFluentInterface
        {
            private readonly CaptchaProperties _captchaProperties;

            public CaptchaPropertiesFluentInterface(CaptchaProperties captchaProperties)
            {
                _captchaProperties = captchaProperties;
            }

            public CaptchaProperties Get()
            {
                return _captchaProperties;
            }

            public CaptchaPropertiesFluentInterface WithBackgroundColor(Color backgroundColor)
            {
                _captchaProperties.BackgroundColor = backgroundColor;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithCharacters(int characters)
            {
                _captchaProperties.Characters = characters <= 0 || characters > 10 ? _captchaProperties._default_characters : characters;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithColorDownUpLine(Color colorDownUpLine)
            {
                _captchaProperties.ColorDownUpLine = colorDownUpLine;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithColorUpDownLine(Color colorUpDownLine)
            {
                _captchaProperties.ColorUpDownLine = colorUpDownLine;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithDownUpLine(bool isVisible)
            {
                _captchaProperties.DrawDownUpLine = isVisible;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithUpDownLine(bool isVisible)
            {
                _captchaProperties.DrawUpDownLine = isVisible;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithRandomCharacters(RandomCharactersType randomCharactersType)
            {
                _captchaProperties.RandomCharacters = randomCharactersType;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithSizeDownUpLine(int size)
            {
                _captchaProperties.SizeDownUpLine = size <= 0 || size > 10 ? _captchaProperties._default_size_down_up_line : size;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithSizeUpDownLine(int size)
            {
                _captchaProperties.SizeUpDownLine = size <= 0 || size > 10 ? _captchaProperties._default_size_up_down_line : size;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithFont(Font stringFont)
            {
                _captchaProperties.StringFont = stringFont;
                return this;
            }

            public CaptchaPropertiesFluentInterface WithFontColor(Color fontColor)
            {
                _captchaProperties.FontColor = fontColor;
                return this;
            }

        }

    }

}