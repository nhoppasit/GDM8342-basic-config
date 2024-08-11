namespace GDM8342L1MauiApp.ViewModels;

public class DCVFlyoutPageCombinedViewModel {
    public CameraViewModel CameraViewModel { get; set; }
    public TwoCamerasC1ViewModel TwoCamerasC1ViewModel { get; set; }
    public TwoCamerasC2ViewModel TwoCamerasC2ViewModel { get; set; }

    public DCVFlyoutPageCombinedViewModel() {
        CameraViewModel = new CameraViewModel();
        TwoCamerasC1ViewModel = new TwoCamerasC1ViewModel();
        TwoCamerasC2ViewModel = new TwoCamerasC2ViewModel();
    }
}
