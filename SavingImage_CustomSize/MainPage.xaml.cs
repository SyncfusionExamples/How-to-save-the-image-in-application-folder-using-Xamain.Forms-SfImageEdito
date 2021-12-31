
namespace SavingImage_CustomSize
{
    using System.IO;
    using Syncfusion.SfImageEditor.XForms;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {
            args.Cancel = true;
            var stream = args.Stream;
            var directory = Path.Combine(FileSystem.AppDataDirectory, "ImageEditorSavedImages");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileFullPath = Path.Combine(directory, "MySavedImage.png");
            this.SaveStreamToFile(fileFullPath, stream);
        }

        private void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0)
            {
                return;
            }

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
    }
}