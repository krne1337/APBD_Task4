using VeterinaryClinicApi.Models;
using System.Collections.Generic;

namespace VeterinaryClinicApi.Data
{
    public static class ClinicDatabase
    {
        public static List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
