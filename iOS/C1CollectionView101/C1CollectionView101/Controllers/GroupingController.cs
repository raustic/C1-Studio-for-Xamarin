using CoreGraphics;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UIKit;
using C1.CollectionView;

namespace C1CollectionView101
{
    public partial class GroupingController : UITableViewController
    {
        private C1CollectionView<YouTubeVideo> _collectionView;

        public GroupingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            var indicator = new UIActivityIndicatorView(new CGRect(0, 0, 40, 40));
            indicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
            indicator.Center = View.Center;
            View.AddSubview(indicator);
            try
            {
                indicator.StartAnimating();
                var videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("Xamarin iOS", "relevance", null, 50)).Item2);
                _collectionView = new C1CollectionView<YouTubeVideo>(videos);
                await _collectionView.GroupAsync(v => v.ChannelTitle);
                TableView.Source = new YouTubeTableViewSource(TableView, _collectionView);
            }
            catch
            {
                var alert = new UIAlertView("", Foundation.NSBundle.MainBundle.LocalizedString("InternetConnectionError", ""), null, "OK");
                alert.Show();
            }
            finally
            {
                indicator.StopAnimating();
            }
        }

    }
}