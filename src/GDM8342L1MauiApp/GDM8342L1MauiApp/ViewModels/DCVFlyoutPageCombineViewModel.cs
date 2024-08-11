namespace GDM8342L1MauiApp.ViewModels;

public class DCVFlyoutPageCombinedViewModel {
    public CameraViewModel CameraViewModel { get; set; }

    public DCVFlyoutPageCombinedViewModel() {
        CameraViewModel = new CameraViewModel();
    }
}
