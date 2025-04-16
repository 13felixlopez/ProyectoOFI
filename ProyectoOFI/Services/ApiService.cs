using Newtonsoft.Json;
using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoOFI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };


            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://192.168.0.102:3000")
            };
        }
        public async Task<List<LControlPatio2>> GetExcelLotesExcelCP()
        {
            var response = await _httpClient.GetAsync("/api/ExcelLotesExcelCP");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var patios = JsonConvert.DeserializeObject<ApiResponse<LControlPatio2>>(jsonResponse);
                return patios.Data;
            }
            return new List<LControlPatio2>();
        }

        //public async Task<List<LControlPatio2>> GetExcelLotesExcelCP()
        //{
        //    var response = await _httpClient.GetAsync("/api/ExcelLotesExcelCP");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stream = await response.Content.ReadAsStreamAsync();
        //        using (var decompressedStream = new BrotliStream(stream, CompressionMode.Decompress))
        //        using (var reader = new StreamReader(decompressedStream))
        //        {
        //            var jsonResponse = await reader.ReadToEndAsync();
        //            var patios = JsonConvert.DeserializeObject<ApiResponse<LControlPatio2>>(jsonResponse);
        //            return patios.Data;
        //        }
        //    }

        //    return new List<LControlPatio2>();
        //}

    }
}
