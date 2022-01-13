using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Models;
using Pconsulta.Models.Election;
using Pconsulta.Models.Login;
using Pconsulta.PageModels;
using Pconsulta.Utilities;
using PropertyChanged;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PrincipalMenuViewModel : FreshBasePageModel
    {
        public LoginResponse PersonData { get; set; }
        public ObservableCollection<Models.Election.Option> propuestas { get; set; } = new ObservableCollection<Models.Election.Option>(){}; 
        public ObservableCollection<Models.Election.Option> votantes { get; set; } = new ObservableCollection<Models.Election.Option>(){};  
        public ObservableCollection<Models.Election.Option> revisor { get; set; } = new ObservableCollection<Models.Election.Option>(){};
        private int yourVote;
        public bool viewbtn { get; set; } = true;
        public string errorsmjProponente { get; set; } 
        public string errorsmjVotante { get; set; } 
        public string errorsmjRevisor { get; set; } 


        public override void Init(object initData = null)
        {
            if (initData != null)
            {
                PersonData = initData as LoginResponse;

                if (PersonData.info.roles.Any(c => c.name.Equals(StaticValues.UserProponente)))
                {
                    Models.Election.Option option = new Models.Election.Option()
                    {
                        title = PersonData.option.title,
                        descript = PersonData.option.descript,
                        id = PersonData.option.id,
                        status = PersonData.option.status,
                        votes = PersonData.option.votes,
                        creator = PersonData.option.creator
                    };
                    
                    if (option.title != null)
                    {
                        propuestas.Add(option);
                        viewbtn = false;
                    }
                    
                    propuestaView = true;
                    if(PersonData.election.status.name != StaticValues.ElecProponer)
                    {
                        viewbtn = false;
                    }
                }
                else
                {
                    propuestaView = false;
                }

                if (PersonData.info.roles.Any(c => c.name.Equals(StaticValues.UserVotante)))
                {
                    if (PersonData.election.status.name == StaticValues.ElecVotar)
                    {
                        Task.Run(async () => await LoadVotanteList());
                        votanteView = true;
                        if (PersonData.vote.id.ToString() != null && PersonData.vote.id.ToString() != "")
                        {
                            yourVote = PersonData.vote.id;

                        }
                    }
                    else
                    {
                        votanteView = false;
                        errorsmjVotante = "La elección se encuentra en el status "+PersonData.election.status.name;
                    }
                }
                else
                {
                    votanteView = false;
                    errorsmjVotante = "No tiene permiso para esta seccion";

                }


                if (PersonData.info.roles.Any(c => c.name.Equals(StaticValues.UserRevisor)))
                {
                    if (PersonData.election.status.name == StaticValues.ElecVotar)
                    {
                        Task.Run(async () => await LoadRevisorList());
                        revisorView = true;
                    }
                    else
                    {
                        revisorView = false;
                        errorsmjRevisor = "La elección se encuentra en el status " + PersonData.election.status.name;
                    }
                }
                else
                {
                    revisorView = false;
                    errorsmjRevisor= "No tiene permiso para esta seccion";

                }
            }
        }

        public override void ReverseInit(object returnedData)
        {

          var option = returnedData as PropuestaEstatus;
            if (option.staus == 1)
            {
                revisor.Remove(option.propuesta);
                votantes.Add(option.propuesta);
            }

            if(option.staus == 2)
            {
                if (yourVote != option.propuesta.id)
                {
                    foreach (var item in votantes)
                    {

                        if(item.id == yourVote)
                        {
                            item.votes -= 1;
                            

                        }
                        if(item.id == option.propuesta.id)
                        {
                            item.votes += 1;
                        }
                    }

                    
                }
                            
                yourVote = option.propuesta.id;

            }

        }

        private async Task LoadRevisorList()
        {
            var loginApi = RestService.For<IOptionServices>(StaticValues.baseUrl);
            var result = await loginApi.GetElection(PersonData.election.id.ToString(), PersonData.token);
            foreach (var op in result.info.Options)
            {
                if (op.status.Equals(false))
                {
                    revisor.Add(op);
                }
            }
        }

        private async Task LoadVotanteList()
        {
            var loginApi = RestService.For<IOptionServices>(StaticValues.baseUrl);
            var result = await loginApi.GetElection(PersonData.election.id.ToString(), PersonData.token);
            var vec = result.info.Options.OrderByDescending(a => a.votes);
            foreach (var op in vec)
            {
                if (op.status.Equals(true))
                {
                    votantes.Add(op);
                }
            }
        }

        public Models.Election.Option itemselectProp { get; set; }
        public Models.Election.Option itemselectvotante { get; set; }
        public Models.Election.Option itemselectrevisor { get; set; }
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
        public Models.Election.Option selectedItemComandRev
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
        public Models.Election.Option selectedItemComandVot
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
        private async void toViewPage(Models.Election.Option itemselect,int status)
        {
            PropuestaEstatus propuestaEstatus = new PropuestaEstatus()
            {
                propuesta = itemselect,
                electionId = PersonData.election.id,
                token = PersonData.token,
                staus = status,
                opcVotada = (yourVote == itemselect.id) ? true : false
            };

            await CoreMethods.PushPageModel<ViewItemViewModel>(propuestaEstatus);
            selectedItemComandProp = null;
            selectedItemComandRev = null;
            selectedItemComandVot = null;
        }        
      
        public bool propuestaView { get; set; }
        public bool votanteView { get; set; }
        public bool revisorView { get; set; }


       
       



        #region "Toolbar"

        public Command Logout => new Command(async () =>
        {
            await CoreMethods.PushPageModel<LoginViewModel>();
        });
        
        public Command toChangePassPage => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ChangePassView>(PersonData.token);
        });

        public Command MakeOptionComand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<MakeOptionViewModel>();
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
