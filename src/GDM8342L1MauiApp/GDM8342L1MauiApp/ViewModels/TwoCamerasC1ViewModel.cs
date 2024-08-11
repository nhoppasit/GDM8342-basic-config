using GDM8342L1MauiApp.Services;
using System.ComponentModel;

namespace GDM8342L1MauiApp.ViewModels;
public class TwoCamerasC1ViewModel : INotifyPropertyChanged {
    private ImageSource _capturedImage;
    public ImageSource CapturedImage {
        get => _capturedImage;
        set {
            _capturedImage = value;
            OnPropertyChanged(nameof(CapturedImage));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task CaptureImageAsync() {
#if WINDOWS
        var cameraService = new TwoCamerasService();
        await cameraService.InitializeCamera1Async();
        var imageStream = await cameraService.CaptureCamera1PhotoAsync();
        CapturedImage = ImageSource.FromStream(() => imageStream);
#endif
    }
}
