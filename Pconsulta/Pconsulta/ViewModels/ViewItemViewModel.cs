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
        public override void Init(object initData = null)
        {
            if (initData != null)
                Propuestas = initData as Propuesta;
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
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("https://gerald.verslu.is/subscribe.pdf");

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);

                await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myFile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
            }
        });

        public Command ToViewImagePageCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<ViewImageViewModel>("https://www.elcarrocolombiano.com/wp-content/uploads/2021/02/20210208-TOP-75-CARROS-MAS-VENDIDOS-DE-COLOMBIA-EN-ENERO-2021-01.jpg");

        });

    }
}
