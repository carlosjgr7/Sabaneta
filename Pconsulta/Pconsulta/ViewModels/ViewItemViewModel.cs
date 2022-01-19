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
        public string urlImgOne { get; set; } = "";
        public string urlImgTwo { get; set; } = "";
        public string urlPdf { get; set; } = "";
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

                if (propuestaEstatus.propuesta.Imgs != null)
                {


                    for (int i = 0; i < propuestaEstatus.propuesta.Imgs.Length; i++)
                    {
                        if (propuestaEstatus.propuesta.Imgs[i].format.Contains("image"))
                        {
                            if (urlImgOne != "")
                            {
                                urlImgTwo = propuestaEstatus.propuesta.Imgs[i].path;
                            }
                            else
                            {
                                urlImgOne = propuestaEstatus.propuesta.Imgs[i].path;
                            }
                        }
                        else
                        {
                            urlPdf = propuestaEstatus.propuesta.Imgs[i].path;
                        }

                    }
                }
                
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
                isloading = true;
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
                isloading = false;

                PreviousPageModel.ReverseInit(returnedData: propuestaEstatus);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

           
         
        });


        public Command RevisorComand => new Command(async () =>
        {
            try
            {
                isloading = true;

                var status = new Dictionary<string, bool>
                {
                    { "status", true }
                };

                var loginApi = RestService.For<IChangeStatus>(StaticValues.baseUrl);
                await loginApi.PutElectionChange(propuestaEstatus.propuesta.id.ToString(), status, token);

                PreviousPageModel.ReverseInit(returnedData: propuestaEstatus);
                isloading = false;

                await CoreMethods.PopPageModel(false);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        });



        public Command ReadPdfCommand => new Command(async () =>
        {
            if (urlPdf != "")
            {
                isloading = true;
                var httpClient = new HttpClient();
                var stream = await httpClient.GetStreamAsync(StaticValues.baseUrl+urlPdf);

                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);

                    await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myFile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
                }
                isloading = false;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("AVISO", "Sin Documentos Cargados", "ok");

            }

        });

        public Command ToViewImagePageCommand => new Command(async () =>
        {
            if (urlImgOne != "")
            {
                var url = StaticValues.baseUrl + urlImgOne;
                isloading = true;
                await CoreMethods.PushPageModel<ViewImageViewModel>(url);
                isloading = false;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("AVISO", "Imagen no Cargada", "ok");

            }

        });

        public Command ToViewImageTwoPageCommand => new Command(async () =>
        {
            if (urlImgTwo != "")
            {
                var url = StaticValues.baseUrl + urlImgTwo;
                isloading = true;
                await CoreMethods.PushPageModel<ViewImageViewModel>(url);
                isloading = false;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("AVISO", "Imagen no Cargada", "ok");
            }


        });

    }
}
