using System.Collections.Generic;

namespace ProyectoOFI.Services
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public List<T> Data { get; set; }
        public string Message { get; set; }
    }
}
