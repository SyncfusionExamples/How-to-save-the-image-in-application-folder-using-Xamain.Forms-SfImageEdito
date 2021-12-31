# How-to-save-the-image-in-application-folder-using-Xamain.Forms-SfImageEditor
This article explains how to save an image in the application data directory using [Syncfusion Xamarin.Forms SfImageEditor](https://help.syncfusion.com/xamarin/image-editor/getting-started) by the following steps
  
**Step 1:** Create a **SfImageEditor** sample with all the necessary assemblies. Please refer to this [Getting started](https://help.syncfusion.com/xamarin/image-editor/getting-started) documentation, to create a simple SfImageEditor sample and configure it.
 
**Step 2:** Using the **ImageSaving** event argument **Cancel**, you can restrict the image saving to the default location as shown in the following code sample. Also, create a folder in an application data directory and save the image using the edited image stream from the **ImageSaving** argument **Stream**. 

**[XAML]**
```
<imageeditor:SfImageEditor x:Name="ImageEditor"
                           Source="{Binding Image}"
                           ImageSaving="ImageEditor_ImageSaving"/>
```

**[C#]**
```
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
    SaveStreamToFile(fileFullPath, stream);
}
```

**Step 3:** Create a FileStream object to write a stream to a file, then fill the bytes[] array with the stream data to write to the specific file.

**[C#]**
```
public void SaveStreamToFile(string fileFullPath, Stream stream)
{
    if (stream.Length == 0) 
    {
        return;
    }

    // Create a FileStream object to write a stream to a file
    using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
    {
        // Fill the bytes[] array with the stream data
        byte[] bytesInStream = new byte[stream.Length];
        stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

        // Use FileStream object to write to the specified file
        fileStream.Write(bytesInStream, 0, bytesInStream.Length);
    }
}
```

Now, edited image will be saved in the respective platform’s application data directory. 

[View the sample from GitHub](https://github.com/SyncfusionExamples/How-to-save-the-image-in-application-folder-using-Xamain.Forms-SfImageEdito)

## See also

[How to restrict the image saving in the default location](https://help.syncfusion.com/xamarin/image-editor/save#imagesaving)

[How to get the location of the saved image](https://help.syncfusion.com/xamarin/image-editor/save#imagesaved)

[How to customize the default toolbar items](https://help.syncfusion.com/xamarin/image-editor/toolbarcustomization)