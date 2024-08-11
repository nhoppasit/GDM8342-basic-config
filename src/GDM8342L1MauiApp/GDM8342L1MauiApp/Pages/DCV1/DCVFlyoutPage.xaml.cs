using GDM8342L1MauiApp.ViewModels;
using System.IO.Ports;

namespace GDM8342L1MauiApp.Pages.DCV1;

public partial class DCVFlyoutPage : FlyoutPage {

    private DCVFlyoutPageCombinedViewModel _viewModel;
    public DCVFlyoutPage() {
        InitializeComponent();
        InitializeSerialPort();
        _viewModel = BindingContext as DCVFlyoutPageCombinedViewModel;
    }

    protected override void OnSizeAllocated(double width, double height) {
        base.OnSizeAllocated(width, height);
        // Check for orientation change and adjust layout accordingly
        if (width > height) // Landscape mode
        {
            if (this.FlyoutLayoutBehavior != FlyoutLayoutBehavior.Split) {
                this.FlyoutLayoutBehavior = FlyoutLayoutBehavior.Split;
            }
        } else // Portrait mode
        {
            if (this.FlyoutLayoutBehavior != FlyoutLayoutBehavior.Default) {
                this.FlyoutLayoutBehavior = FlyoutLayoutBehavior.Default;
            }
        }
    }

    private void ButtonTestConnection_Clicked(object sender, EventArgs e) {
        Test();
    }

    SerialPort _serialPort;
    void InitializeSerialPort() {
        _serialPort = new SerialPort("COM4", 115200); // Replace COM3 with your actual COM port
        _serialPort.Open();
    }

    void Test() {
        try {
            // Ensure the serial port is open
            if (_serialPort.IsOpen) {
                // Send the *IDN? command
                _serialPort.WriteLine("*IDN?");

                // Read the response
                string response = _serialPort.ReadLine();

                // Display the response
                Dispatcher.Dispatch(() => {
                    DisplayAlert("GDM8342 Response", response, "OK");
                });
            } else {
                Dispatcher.Dispatch(() => {
                    DisplayAlert("Error", "Serial port is not open.", "OK");
                });
            }
        } catch (Exception ex) {
            // Handle exceptions
            Dispatcher.Dispatch(() => {
                DisplayAlert("Error", ex.Message, "OK");
            });
        }
    }

    private async void CaptureButton_Clicked(object sender, EventArgs e) {
        await _viewModel.CameraViewModel.CaptureImageAsync();
    }
}