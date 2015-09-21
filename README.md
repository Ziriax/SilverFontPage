# SilverFontPage
Tiny project to help the Google font tool developers reproduce font crashes in Silverlight

Usage:

NOTE: You should use Internet Explorer for testing this, since other browsers started blocking the Silverlight plugin.

Either build the project using Visual Studio 2013+, or use the published version on my website:

[This uses the oswald-light.ttf font from FontSquirrel, and works (it displays 'the quick brown fox')](http://strongly-typed.net/google/?family=oswald&source=OswaldLightOK.ttf)

[This uses the oswald-light.ttf font from GoogleFonts, and crashes](http://strongly-typed.net/google/?family=oswald&source=OswaldLightBAD.ttf)

[This uses the working oswald-light.ttf font from FontSquirrel, but round-tripped using TTX, and also crashes](http://strongly-typed.net/google/?family=oswald&source=OswaldLightTTX.ttf)



