using System;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Documents;
using System.Windows.Media;

namespace SilverFontPage
{
	public partial class MainPage 
	{
		public MainPage()
		{
			InitializeComponent();

			string fontFamily;
			if (!HtmlPage.Document.QueryString.TryGetValue("family", out fontFamily))
			{
				LogError("Missing required family query string parameter");
				return;
			}

			string fontSource = fontFamily + ".zip";
			FontWeight fontWeight = FontWeights.Normal;
			FontStyle fontStyle = FontStyles.Normal;
			FontStretch fontStretch = FontStretches.Normal;
			double fontSize = 100;

			string queryStringValue;
			if (HtmlPage.Document.QueryString.TryGetValue("source", out queryStringValue))
				fontSource = queryStringValue;

			if (HtmlPage.Document.QueryString.TryGetValue("weight", out queryStringValue))
				Enum.TryParse(queryStringValue, out fontWeight);

			if (HtmlPage.Document.QueryString.TryGetValue("style", out queryStringValue))
				Enum.TryParse(queryStringValue, out fontStyle);

			if (HtmlPage.Document.QueryString.TryGetValue("stretch", out queryStringValue))
				Enum.TryParse(queryStringValue, out fontStretch);

			if (HtmlPage.Document.QueryString.TryGetValue("size", out queryStringValue))
				Double.TryParse(queryStringValue, out fontSize);

			var wc = new WebClient();
			var fontFamilyUri = new Uri(Application.Current.Host.Source, fontSource);
			wc.OpenReadCompleted += (sender, e) =>
			{
				if (e.Error != null)
				{
					LogError("Error while loading the ZIP stream {0}: {1}", fontFamilyUri, e.Error);
					return;
				}

				m_TextBlock.FontFamily = new FontFamily(fontFamily + ", Courier New");
				m_TextBlock.FontSource = new FontSource(e.Result);
				m_TextBlock.FontWeight = fontWeight;
				m_TextBlock.FontStyle = fontStyle;
				m_TextBlock.FontStretch = fontStretch;
				m_TextBlock.FontSize = fontSize;
			};
			wc.OpenReadAsync(fontFamilyUri);
		}

		private void LogError(string text, params object[] args)
		{
			var msg = args.Length == 0 ? text : string.Format(text, args);

			m_TextBlock.Text = msg;
			m_TextBlock.Foreground = new SolidColorBrush(Colors.Red);
		}
	}
}
