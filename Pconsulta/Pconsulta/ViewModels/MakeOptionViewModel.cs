using FreshMvvm;
using Newtonsoft.Json;
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
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MakeOptionViewModel: FreshBasePageModel
    {
        public string title { get; set; } 
        public string description { get; set; } 
        public bool Loading { get; set; }
        public LoginResponse personData { get; set; }
        public ImageSource imgOne { get; set; }
        public ImageSource imgTwo { get; set; }
        public bool loadPdf { get; set; }

        public FileResult stream1 { get; set; } = null;
        public FileResult stream2 { get; set; } = null;
        public FileResult stream3 { get; set; } = null;

        public override void Init(object initData)
        {
            personData = initData as LoginResponse;
        }

        
        public Command SendPropuestaCommand => new Command(async () =>
        {
            await Application.Current.MainPage.DisplayAlert("Aviso", "Su propuesta se esta creando, No salga de esta pantalla", "ok");
            Loading = true;

            NewOptionModel newOptionModel = new NewOptionModel()
            {
                title = title,
                descript = description,
                election = personData.election.id
            };
            if(newOptionModel.title != null ||newOptionModel.descript != null)
            {
                try
                {
                    var apiServices = RestService.For<INewOption>(StaticValues.baseUrl);
                    var result = await apiServices.PostNewOption(
                        newOptionModel,
                        personData.token
                        );

                    if (result.message.Length > 0)
                    {
                        if (stream1 != null)
                        {
                            var files = new StreamPart(await stream1.OpenReadAsync(), "imagen1.jpg", "image/jpeg");
                            try
                            {
                                var api = RestService.For<IAddImageToOption>(StaticValues.baseUrl);
                                await api.UploadImages(result.info.id, files, personData.token);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }

                        if (stream2 != null)
                        {
                            var files = new StreamPart(await stream2.OpenReadAsync(), "imagen2.jpg", "image/jpeg");
                            try
                            {
                                var api = RestService.For<IAddImageToOption>(StaticValues.baseUrl);
                                await api.UploadImages(result.info.id, files, personData.token);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }

                        if (stream3 != null)
                        {
                            var files = new StreamPart(await stream3.OpenReadAsync(), "doc.pdf", "application/pdf");
                            try
                            {
                                var api = RestService.For<IAddImageToOption>(StaticValues.baseUrl);
                                await api.UploadImages(result.info.id, files, personData.token);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        Loading = false;
                        await Application.Current.MainPage.DisplayAlert("Exitoso", "Su propuesta fue creada con exito... Hasta luego", "ok");
                        await CoreMethods.PushPageModel<LoginViewModel>();


                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "El titulo y la descripcion de su propuesta no pueden estar vacios", "ok");

            }


        });


      
    public Command UploadImgCommand => new Command(async () =>
        {

           stream1 = await MediaPicker.PickPhotoAsync();

            if (stream1 == null)
                return;

            var strm = await stream1.OpenReadAsync();
            
            imgOne = ImageSource.FromStream(() => strm);


        });



        public Command UploadImgTwoCommand => new Command(async () =>
        {
            stream2 = await MediaPicker.PickPhotoAsync();

            if (stream2 == null)
                return;

            var strm = await stream2.OpenReadAsync();
            imgTwo = ImageSource.FromStream(() => strm);

        });

        public Command UploadPdfCommand => new Command(async () =>
        {
            stream3 = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Pdf,
                PickerTitle = "pdfPropuesta"
            });

            if (stream3 == null)
                return;     
                loadPdf = true;
            
        });

    }
}
