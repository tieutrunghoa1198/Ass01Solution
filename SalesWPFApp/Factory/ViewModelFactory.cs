using SalesWPFApp.ViewModel.Interface;

namespace SalesWPFApp.Factory
{
    internal class ViewModelFactory
    {
        // Singleton
        private static ViewModelFactory instance = null;
        private static readonly object instanceLock = new object();
        public IDialog dialog(string type)
        {
            IDialog dialog = null;
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
            return dialog;
        }
        private ViewModelFactory() { }
        public static ViewModelFactory Instance()
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ViewModelFactory();
                    }
                }
            }

            return instance;
        }
    }
}
