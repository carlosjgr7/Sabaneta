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
        private ObservableCollection<Propuesta> propuestas { get; set; } = new ObservableCollection<Propuesta>()
        {
            new Propuesta
            {
                Title = "Propuesta test 1",
                Description ="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            }
        }; 
        private ObservableCollection<Propuesta> votantes { get; set; } = new ObservableCollection<Propuesta>()
        {
            new Propuesta
            {
                Title = "Propuesta test 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },            
            new Propuesta
            {
                Title = "Propuesta test 2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "Propuesta test 3",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "Propuesta test 4",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "Propuesta test 5",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
        };  
        private ObservableCollection<Propuesta> revisor { get; set; } = new ObservableCollection<Propuesta>()
        {
            new Propuesta
            {
                Title = "Propuesta test 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },            
            new Propuesta
            {
                Title = "Propuesta test 2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "Propuesta test 3",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "Propuesta test 4",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
            new Propuesta
            {
                Title = "Propuesta test 5",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
        };
        public override void Init(object initData = null)
        {
            if (initData != null)
                PersonData = initData as LoginResponseModel;
        }
        public Propuesta itemselectProp { get; set; }
        public Propuesta itemselectvotante { get; set; }
        public Propuesta itemselectrevisor { get; set; }
        public Propuesta selectedItemComandProp
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
        public Propuesta selectedItemComandRev
        {
            get => itemselectrevisor;
            set
            {
                itemselectrevisor = value;
                RaisePropertyChanged(nameof(selectedItemComandRev));
                if (itemselectrevisor != null)
                {
                    toViewPage(itemselectrevisor, 1);
                }

            }

        }
        public Propuesta selectedItemComandVot
        {
            get => itemselectvotante;
            set
            {
                itemselectvotante = value;
                RaisePropertyChanged(nameof(selectedItemComandVot));
                if (itemselectvotante != null)
                {
                    toViewPage(itemselectvotante, 2);
                }

            }

        }
        private async void toViewPage(Propuesta itemselect,int status)
        {
            PropuestaEstatus propuestaEstatus = new PropuestaEstatus()
            {
                propuesta = itemselect,
                staus = status
            };         
            await CoreMethods.PushPageModel<ViewItemViewModel>(propuestaEstatus);
            selectedItemComandProp = null;
            selectedItemComandRev = null;
            selectedItemComandVot = null;
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
        public ObservableCollection<Propuesta> Votante
        {
            get => votantes;
            set
            {
                votantes = value;
                RaisePropertyChanged(nameof(Votante));
            }
        }    
        public ObservableCollection<Propuesta> Revisor
        {
            get => revisor;
            set
            {
                revisor = value;
                RaisePropertyChanged(nameof(Revisor));
            }
        }
        public bool propuestaView { get; set; } = false;
        public bool votanteView { get; set; } = true;
        public bool revisorView { get; set; } = false;

        public bool PropuestaView
        {
            get => propuestaView;
            set
            {
                propuestaView = value;
                RaisePropertyChanged(nameof(PropuestaView));
            }
        } 
        public bool VotanteView
        {
            get => votanteView;
            set
            {
                propuestaView = value;
                RaisePropertyChanged(nameof(VotanteView));
            }
        }
        public bool RevisorView
        {
            get => revisorView;
            set
            {
                propuestaView = value;
                RaisePropertyChanged(nameof(RevisorView));
            }
        }



        #region "Toolbar"

        public Command Logout => new Command(async () =>
        {
            await CoreMethods.PushPageModel<LoginViewModel>();
        });
        
        public Command toChangePassPage => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ChangePassView>();
        });




        #endregion
        #region "time"
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
        #endregion



    }

}
