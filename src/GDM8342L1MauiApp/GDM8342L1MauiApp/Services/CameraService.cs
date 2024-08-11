#if WINDOWS
using Microsoft.Maui.Controls;
using Windows.Media.Capture;
using Windows.Storage.Streams;

namespace GDM8342L1MauiApp.Services;

public class CameraService {
    private MediaCapture _mediaCapture;

    public async Task InitializeCameraAsync() {
        _mediaCapture = new MediaCapture();
        await _mediaCapture.InitializeAsync();
    }

    public async Task<Stream> CapturePhotoAsync() {
        var stream = new InMemoryRandomAccessStream();
        await _mediaCapture.CapturePhotoToStreamAsync(
            Windows.Media.MediaProperties.ImageEncodingProperties.CreateJpeg(), stream);

        stream.Seek(0);
        return stream.AsStream();
    }
}

#endif
