using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Models;
using Pconsulta.PageModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    public class PrincipalMenuViewModel : FreshBasePageModel
    {
        public LoginResponseModel PersonData { get; set; }
        public ObservableCollection<Propuesta> propuestas { get; set; } = new ObservableCollection<Propuesta>()
        {
            new Propuesta
            {
                Title = "propuesta test 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },            
            new Propuesta
            {
                Title = "propuesta test 2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "propuesta test 3",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "propuesta test 4",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "propuesta test 5",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
        };

        public override void Init(object initData = null)
        {
            if (initData!=null)
            PersonData = initData as LoginResponseModel;
        }

        public Propuesta itemselect { get; set; }

        public Propuesta selectedItemComand
        { 
            get => itemselect;
            set
            {
                itemselect = value;
                RaisePropertyChanged(nameof(selectedItemComand));
                if (itemselect != null)
                {
                    toViewPage(itemselect);
                }

            }

        }

        private async void toViewPage(Propuesta itemselect)
        {
            
            await CoreMethods.PushPageModel<ViewItemViewModel>(itemselect);
            selectedItemComand = null;
        }





        #region "Toolbar"
        private string _toolbarName { get; } = "Cerrar Sesión";
        public string ToolbarName
        {
            get => _toolbarName;
        }
        public Command Logout => new Command(async () =>
        {
            Time = DateTime.Now.ToString();
            await CoreMethods.PushPageModel<LoginViewModel>();
        });




        #endregion

        #region "Movimientos_Tab"

            
        const string _time = "myTime";

        public string Time
        {
            get => Preferences.Get(_time, DateTime.Now.ToString());
            set
            {
                Preferences.Set(_time, value);
                RaisePropertyChanged(nameof(Time));
            }
        }

        public ObservableCollection<Propuesta> Propuestas
        {
            get => propuestas;
            set
            {
                propuestas = value;
                RaisePropertyChanged(nameof(Propuesta));
            }
        }

        #endregion
        #region "CierreLote_Tab"



        #endregion
        #region "Services_Tab"



        #endregion

    }

}
