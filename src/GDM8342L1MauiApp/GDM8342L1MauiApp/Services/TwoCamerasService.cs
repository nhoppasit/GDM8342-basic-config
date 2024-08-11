#if WINDOWS
using Microsoft.Maui.Controls;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.Storage.Streams;

namespace GDM8342L1MauiApp.Services {
    public class TwoCamerasService {
        private MediaCapture _camera1Capture;
        private MediaCapture _camera2Capture;

        // Initialize the laptop camera
        public async Task InitializeCamera1Async() {
            var camera1 = await GetCameraDeviceAsync("Laptop Camera"); // Adjust the name to match the actual device
            if (camera1 == null)
                throw new Exception("Laptop camera not found");

            _camera1Capture = new MediaCapture();
            await _camera1Capture.InitializeAsync(new MediaCaptureInitializationSettings {
                VideoDeviceId = camera1.Id,
                StreamingCaptureMode = StreamingCaptureMode.Video
            });
        }

        // Initialize the USB camera
        public async Task InitializeCamera2Async() {
            var camera2 = await GetCameraDeviceAsync("USB Camera"); // Adjust the name to match the actual device
            if (camera2 == null)
                throw new Exception("USB camera not found");

            _camera2Capture = new MediaCapture();
            await _camera2Capture.InitializeAsync(new MediaCaptureInitializationSettings {
                VideoDeviceId = camera2.Id,
                StreamingCaptureMode = StreamingCaptureMode.Video
            });
        }

        // Capture photo from the laptop camera
        public async Task<Stream> CaptureCamera1PhotoAsync() {
            if (_camera1Capture == null)
                throw new InvalidOperationException("Camera-1 not initialized");

            var stream = new InMemoryRandomAccessStream();
            await _camera1Capture.CapturePhotoToStreamAsync(
                Windows.Media.MediaProperties.ImageEncodingProperties.CreateJpeg(), stream);

            stream.Seek(0);
            return stream.AsStream();
        }

        // Capture photo from the USB camera
        public async Task<Stream> CaptureCamera2PhotoAsync() {
            if (_camera2Capture == null)
                throw new InvalidOperationException("Camera-2 not initialized");

            var stream = new InMemoryRandomAccessStream();
            await _camera2Capture.CapturePhotoToStreamAsync(
                Windows.Media.MediaProperties.ImageEncodingProperties.CreateJpeg(), stream);

            stream.Seek(0);
            return stream.AsStream();
        }

        // Helper method to get the camera device by name
        private async Task<DeviceInformation> GetCameraDeviceAsync(string deviceName) {
            var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            return allVideoDevices.FirstOrDefault(device => device.Name.Contains(deviceName));
        }
    }
}
#endif
