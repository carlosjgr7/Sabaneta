using FreshMvvm;

namespace Pconsulta.ViewModels
{
    public class GraphicsViewModel:FreshBasePageModel
    {
        private string _wellcome { get; set; } = "test Navigation";

        public string Wellcome
        {
            get => _wellcome;
            set
            {
                _wellcome = value;

            }
        }
    }
}
