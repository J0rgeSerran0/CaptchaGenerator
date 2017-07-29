namespace CaptchaGenerator
{

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;

    public class Builder
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        private const string LOWER_CASE_LETTERS = "abcdefghijklmnopqrstuvwyxz";
        private const string NUMBERS = "0123456789";
        private const string UPPER_CASE_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string GetPattern(RandomCharactersType randomCharactersType)
        {
            var pattern = LOWER_CASE_LETTERS + UPPER_CASE_LETTERS + NUMBERS;

            switch (randomCharactersType)
            {
                case RandomCharactersType.LowerCaseLetters:
                    pattern = LOWER_CASE_LETTERS;
                    break;
                case RandomCharactersType.LowerAndUpperCaseLetters:
                    pattern = LOWER_CASE_LETTERS + UPPER_CASE_LETTERS;
                    break;
                case RandomCharactersType.LowerCaseLettersAndNumbers:
                    pattern = LOWER_CASE_LETTERS + NUMBERS;
                    break;
                case RandomCharactersType.Numbers:
                    pattern = NUMBERS;
                    break;
                case RandomCharactersType.UpperCaseLetters:
                    pattern = UPPER_CASE_LETTERS;
                    break;
                case RandomCharactersType.UpperCaseLettersAndNumbers:
                    pattern = UPPER_CASE_LETTERS + NUMBERS;
                    break;
                default:
                    break;
            }

            return pattern;
        }

        private SizeF GetStringSize(string text, Font stringFont)
        {
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);

            var stringSize = graphics.MeasureString(text, stringFont);

            bitmap.Dispose();
            graphics.Dispose();

            return stringSize;
        }

        private string RandomString(int size, RandomCharactersType randomCharactersType)
        {
            var pattern = GetPattern(randomCharactersType);
            var characters = Enumerable.Range(0, size).Select(x => pattern[random.Next(0, pattern.Length)]);

            return new string(characters.ToArray());
        }

        public Tuple<Image, string> CreateImage(CaptchaProperties captchaProperties = null)
        {
            captchaProperties = captchaProperties == null ? new CaptchaProperties() : captchaProperties;

            var text = RandomString(captchaProperties.Characters, captchaProperties.RandomCharacters);
            var stringFont = captchaProperties.StringFont;

            var stringSize = GetStringSize(text, stringFont);

            var bitmap = new Bitmap(Convert.ToInt32(stringSize.Width), Convert.ToInt32(stringSize.Height));
            var graphics = Graphics.FromImage(bitmap);

            graphics.Clear(captchaProperties.BackgroundColor);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            
            graphics.DrawString(text, stringFont, new SolidBrush(captchaProperties.FontColor), new PointF(0, 0));

            if (captchaProperties.DrawDownUpLine)
                graphics.DrawLine(new Pen(captchaProperties.ColorDownUpLine, captchaProperties.SizeDownUpLine), 0.0F, stringSize.Height, stringSize.Width, 0.0F);

            if (captchaProperties.DrawUpDownLine)
                graphics.DrawLine(new Pen(captchaProperties.ColorUpDownLine, captchaProperties.SizeUpDownLine), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            graphics.Flush();

            return new Tuple<Image, string>(bitmap, text);
        }

    }

}