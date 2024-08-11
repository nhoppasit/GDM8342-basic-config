namespace GDM8342L1MauiApp.Pages.DCV1;

public partial class DCVFlyoutPage : FlyoutPage {
    public DCVFlyoutPage() {
        InitializeComponent();
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
}