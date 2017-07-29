# CaptchaGenerator
Captcha Generator Library for .NET Framework

## Description
This sample show you how generate a captcha for your applications.
You will be able to apply different settings to generate the captcha.

### Execution Demo
![screenshot](https://raw.githubusercontent.com/J0rgeSerran0/CaptchaGenerator/master/CaptchaGenerator_WindowsDemo.png)

## Configuration
You will be able to configure the captcha with:
* Background Color
* Number of characters (from 1 to 10 maximum, with 5 characters by default)
* Color of the line that goes from down and left corner, to up and right corner of the image
* Color of the line that goes from up and left corner, to down and right corner of the image
* Option to show the line that goes from down and left corner, to up and right corner of the image
* Option to show the line that goes from up and left corner, to down and right corner of the image
* Random characters with an enum to choice if you want to include lower case letters, upper case letters, and/or numbers
* Size of the line that goes from down and left corner, to up and right corner of the image
* Size of the line that goes from up and left corner, to down and right corner of the image
* Font Name and settings of the font (strikeout, bold, italic, etc)
* Font Color

## Sample use
* Basic call to generate a Captcha:
```csharp
var captchaProperties = new CaptchaGenerator.CaptchaProperties()
    .Configure
    .Get();
```

* Execution call to generate a Captcha with all settings applied (as you can see in the image shown in the execution demo section of this readme file):
```csharp
var captchaProperties = new CaptchaGenerator.CaptchaProperties()
    .Configure
    .WithBackgroundColor(Color.White)
    .WithCharacters(6)
    .WithColorDownUpLine(Color.Gray)
    .WithColorUpDownLine(Color.Gray)
    .WithDownUpLine(true)
    .WithUpDownLine(true)
    .WithRandomCharacters(CaptchaGenerator.RandomCharactersType.All)
    .WithSizeDownUpLine(2)
    .WithSizeUpDownLine(2)
    .WithFont(new Font("Segoe UI", 24, FontStyle.Strikeout))
    .WithFontColor(Color.DarkSlateGray)
    .Get();
```
