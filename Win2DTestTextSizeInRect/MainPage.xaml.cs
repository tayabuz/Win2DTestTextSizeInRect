using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Win2DTestTextSizeInRect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            CanvasDrawingSession drawingSession = args.DrawingSession;
            const float xLoc = 100.0f;
            const float yLoc = 100.0f;
            // 1)
            const int heightRect = 200;
            const int widthRect = 100;
            string text = "1";
            // 2)
            /*
            const int heightRect = 100;
            const int widthRect = 400;
            string text = "1234567890";
            */
            // 3)
            /*
            const int heightRect = 100;
            const int widthRect = 500;
            string text = "12345678909876543210";
            */
            // 4)
            /*const int heightRect = 30;
            const int widthRect = 500;
            string text = "1234567890";
            */
            //const string font = "ms-appx:///Path to font/font.ttf#font";
            CanvasTextFormat format = new CanvasTextFormat 
	        { 
		        FontSize = 130f, 
		        WordWrapping = CanvasWordWrapping.NoWrap, 
		        HorizontalAlignment = (CanvasHorizontalAlignment) HorizontalAlignment.Left, 
		        VerticalAlignment = (CanvasVerticalAlignment) VerticalAlignment.Bottom 
		        //, FontFamily = font 
            };
            CanvasTextLayout textLayout = new CanvasTextLayout(drawingSession, text, format, 0.0f, 0.0f);
            Rect theRectYouAreLookingFor = new Rect(xLoc, yLoc, widthRect, heightRect);
            const float eps = 0.1f;
            while (textLayout.LayoutBounds.Width > theRectYouAreLookingFor.Width || textLayout.LayoutBounds.Height > theRectYouAreLookingFor.Height)
            {
                float Size = format.FontSize - eps;
                format.FontSize = Size;
                textLayout = new CanvasTextLayout(drawingSession, text, format, 0.0f, 0.0f);
            }
            drawingSession.DrawRectangle(theRectYouAreLookingFor, Colors.Green, 3.0f);
            drawingSession.DrawTextLayout(textLayout, xLoc + (widthRect / 2) - (float)(textLayout.LayoutBounds.Width / 2), yLoc + (heightRect / 2), Colors.Black);
        }
    }
}
