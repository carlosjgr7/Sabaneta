using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    public interface IAddImageToOption
    {
        [Multipart]
        [Put("/options/{id}/img")]
        Task UploadImages(int id, [AliasAs("images")] StreamPart streams, [Header("authorization")] string token);
        
    }
}
