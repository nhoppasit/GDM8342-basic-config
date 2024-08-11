﻿using GDM8342L1MauiApp.Services;
using System.ComponentModel;

namespace GDM8342L1MauiApp.ViewModels;
public class CameraViewModel : INotifyPropertyChanged {
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
        var cameraService = new CameraService();
        await cameraService.InitializeCameraAsync();
        var imageStream = await cameraService.CapturePhotoAsync();
        CapturedImage = ImageSource.FromStream(() => imageStream);
#endif
    }
}
