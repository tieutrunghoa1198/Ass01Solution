using SalesWPFApp.ViewModel.Interface;
namespace SalesWPFApp.ViewModel
{
    internal class ViewModelFactory
    {
        public IDialog dialog { get; private set; }
        public ViewModelFactory(string type)
        {
            switch (type)
            {
                case "product":
                    dialog = ProductWindow.Instance;
                    break;
                case "order": 
                    dialog = OrderWindow.Instance; 
                    break;
                case "member":
                    dialog = MemberWindow.Instance;
                    break;
            }
        }
    }
}
