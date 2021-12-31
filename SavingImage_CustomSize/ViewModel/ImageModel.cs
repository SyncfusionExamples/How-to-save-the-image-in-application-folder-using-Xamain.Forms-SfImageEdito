
namespace SavingImage_CustomSize
{
    using Xamarin.Forms;

    class ImageModel
    {
        public ImageSource Image { get; set; }

        public ImageModel()
        {
            Image = ImageSource.FromResource("SavingImage_CustomSize.Buildingimage.jpeg");
        }
    }
}