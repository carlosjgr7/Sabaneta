using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.ViewModels
{
    class ViewImageViewModel : FreshBasePageModel
    {
        public string _urlImage { get; set; }
        public override void Init(object initData = null)
        {
            if (initData != null)
                UrlImage = initData as string;
        }

        public string UrlImage
        {
            get => _urlImage;
            set
            {
                _urlImage = value;
                RaisePropertyChanged(nameof(UrlImage));
            }

        }
    }
}
