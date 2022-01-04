using FreshMvvm;
using Pconsulta.Models;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    class ViewItemViewModel: FreshBasePageModel
    {
        public Propuesta propuestas { get; set; }
        public string selectItem { get; set; }
        public string imageVotation { get; set; } = "like.png";
        public bool opcVotada { get; set; } = false;
        private bool _isloading { get; set; } = false;



        public bool votante { get; set; } = false;
        public bool revisor { get; set; } = false;
        private PropuestaEstatus propuestaEstatus;


        public override void Init(object initData = null)
        {
            if (initData != null)
            {
                propuestaEstatus = initData as PropuestaEstatus;
                propuestas = propuestaEstatus.propuesta;
            }
           
            
            if (propuestaEstatus.staus == 1)
            {
                Votante = false;
                Revisor = true;
            }
            if (propuestaEstatus.staus == 2)
            {
                Votante = true;
                Revisor = false;
            }
        }

        public Propuesta Propuestas
        {
            get => propuestas;
            set
            {
                propuestas = value;
                RaisePropertyChanged(nameof(Propuestas));
            }
        }
        public bool Loading
        {
            get => _isloading;
            set
            {
                _isloading = value;
                RaisePropertyChanged(nameof(Loading));
            }
        }
        public string ImageVotation
        {
            get => imageVotation;
            set
            {
                imageVotation = value;
                RaisePropertyChanged(nameof(ImageVotation));
            }
        }

        public bool Votante
        {
            get => votante;
            set
            {
                votante = value;
                RaisePropertyChanged(nameof(votante));
            }
        }    
        
        public bool Revisor
        {
            get => revisor;
            set
            {
                revisor = value;
                RaisePropertyChanged(nameof(Revisor));
            }
        }


        public Command VotationCommand => new Command(async () =>
        {
            if (!opcVotada)
            {
                ImageVotation = "likeIn.png";
            }
         
        });


        public string SelectItem
        {
            get => selectItem;
            set
            {
                selectItem = null;
                RaisePropertyChanged(nameof(SelectItem));
            }

        }

        public Command ReadPdfCommand => new Command(async () =>
        {
            Loading = true;
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("https://gerald.verslu.is/subscribe.pdf");

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);

                await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myFile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
            }
            Loading = false;
        });

        public Command ToViewImagePageCommand => new Command(async () =>
        {
            Loading = true;
            await CoreMethods.PushPageModel<ViewImageViewModel>("https://www.elcarrocolombiano.com/wp-content/uploads/2021/02/20210208-TOP-75-CARROS-MAS-VENDIDOS-DE-COLOMBIA-EN-ENERO-2021-01.jpg");
            Loading = false;

        });

    }
}
