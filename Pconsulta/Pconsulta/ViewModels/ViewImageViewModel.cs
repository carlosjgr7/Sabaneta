using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ViewImageViewModel : FreshBasePageModel
    {
        public string urlImage { get; set; }
        public override void Init(object initData = null)
        {
            if (initData != null)
                urlImage = initData as string;
        }

        
    }
}
