using FreshMvvm;
using Pconsulta.Models.Election;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Pconsulta.Utilities;
using Pconsulta.Models;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewLastWinViewModel: FreshBasePageModel
    {
        public ObservableCollection<Models.Election.Option> LastView { get; set; } = new ObservableCollection<Models.Election.Option>(){};
        public ElectionList Eleccion { get; set; } = new ElectionList();
        private Option option = new Option();
        public string finish { get; set; }

        public override void Init(object initData)
        {
            Eleccion = initData as ElectionList;

            var opt = Eleccion.info.Options.Where(x=>x.status).OrderByDescending(x => x.votes);
            foreach (var item in opt)
            {
                if (option.title == null || option.votes == item.votes)
                {
                    option = item;
                    LastView.Add(option);
                }
                
            }

            if(Eleccion.info.status.name != StaticValues.ElecFinalizada)
            {
                finish = "La eleccion aun no ha finalizado";
            }
            else
            {
                finish = "";
            }

        }

        public Models.Election.Option itemselectProp { get; set; }

        public Models.Election.Option selectedItemComandProp
        {
            get => itemselectProp;
            set
            {
                itemselectProp = value;
                RaisePropertyChanged(nameof(selectedItemComandProp));
                if (itemselectProp != null)
                {
                    toViewPage(itemselectProp, 0);
                }

            }

        }

        private async void toViewPage(Models.Election.Option itemselect, int status)
        {
            PropuestaEstatus propuestaEstatus = new PropuestaEstatus()
            {
                propuesta = itemselect,
                electionId = Eleccion.info.id,
                staus = status,
            };

            await CoreMethods.PushPageModel<ViewItemViewModel>(propuestaEstatus);
            selectedItemComandProp = null;
          
        }
    }
}
