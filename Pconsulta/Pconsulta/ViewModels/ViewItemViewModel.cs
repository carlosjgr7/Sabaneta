using FreshMvvm;
using Pconsulta.Models;
using Pconsulta.Models.Login;
using Pconsulta.Models.Election;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Refit;
using Pconsulta.Interfaces;
using Pconsulta.Utilities;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PropertyChanged;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ViewItemViewModel: FreshBasePageModel
    {
        public Models.Election.Option propuestas { get; set; }
        public string selectItem { get; set; }
        public string imageVotation { get; set; } = "like.png";
        public bool opcVotada { get; set; } 
        public bool isloading { get; set; } = false;
        public bool votante { get; set; } = false;
        public bool revisor { get; set; } = false;
        private PropuestaEstatus propuestaEstatus;
        private int electionId;
        private string token;


        public override void Init(object initData = null)
        {
            if (initData != null)
            {
                propuestaEstatus = initData as PropuestaEstatus;
                electionId = propuestaEstatus.electionId;
                token = propuestaEstatus.token;
                propuestas = propuestaEstatus.propuesta;
                opcVotada = propuestaEstatus.opcVotada;
                
                if (opcVotada)
                {
                    imageVotation = "likeIn.png";
                }
            }
           
            
            if (propuestaEstatus.staus == 1)
            {
                votante = false;
                revisor = true;
            }
            if (propuestaEstatus.staus == 2)
            {
                votante = true;
                revisor = false;
            }
        }

 

        public Command VotationCommand => new Command(async () =>
        {
            try
            {
                Dictionary<string, string> msj = new Dictionary<string, string>()
                {
                    {"msj","ok" }
                };
                var loginApi = RestService.For<IVoteOptions>(StaticValues.baseUrl);
                await loginApi.PutVotation(electionId.ToString(), propuestaEstatus.propuesta.id.ToString(),msj, token);
               
                if (!opcVotada)
                {
                    imageVotation = "likeIn.png";
                    opcVotada = true;
                }

                PreviousPageModel.ReverseInit(returnedData: propuestaEstatus);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

           
         
        });


        public Command RevisorComand => new Command(async () =>
        {
            var change = new changeOptions
            {
                status = true
            };

            var loginApi = RestService.For<IChangeStatus>(StaticValues.baseUrl);
            await loginApi.PutElectionChange(propuestaEstatus.propuesta.id.ToString(), change,token);
            
            PreviousPageModel.ReverseInit(returnedData: propuestaEstatus);
            await CoreMethods.PopPageModel(false);

        });



        public Command ReadPdfCommand => new Command(async () =>
        {
            isloading = true;
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("https://gerald.verslu.is/subscribe.pdf");

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);

                await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myFile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
            }
            isloading = false;
        });

        public Command ToViewImagePageCommand => new Command(async () =>
        {
            isloading = true;
            await CoreMethods.PushPageModel<ViewImageViewModel>("https://www.elcarrocolombiano.com/wp-content/uploads/2021/02/20210208-TOP-75-CARROS-MAS-VENDIDOS-DE-COLOMBIA-EN-ENERO-2021-01.jpg");
            isloading = false;

        });

    }
}
