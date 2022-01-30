using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CognizantTest.LoadedEntities;
using Newtonsoft.Json;

namespace CognizantTest.DataEntities
{
    public abstract class DbObjs
    {
        [JsonProperty("_id")]
        public int OuterId { get; set; }

        public int Id { get; set; }

        [JsonProperty("name")]
        [MaxLength(200)]
        public string Name { get; set; }
    }

    public class Warehouse : DbObjs
    {
        public Warehouse()
        {

        }

        public Warehouse(IncEntity storage)
        {
            OuterId = storage.Id;
            Name = storage.Name;
            Location = storage.Location.Lat + " " + storage.Location.Long;
        }

        [JsonProperty("location")]
        public string Location { get; set; }
    }

    public class Vehicle : DbObjs
    {
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        [Required]
        public Warehouse Warehouse { get; set; }

        [JsonProperty("make")]
        [NotMapped]
        public string BrandJson { get; set; }

        public int? BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [JsonProperty("model")]
        [NotMapped]
        public string ModelJson { get; set; }

        public int? ModelId { get; set; }

        [ForeignKey("ModelId")]
        public Model Model { get; set; }

        [JsonProperty("year_model")]
        public int YearModel { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("licensed")]
        public bool Licensed { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }
    }

    public class Brand : DbObjs
    {

    }

    public class Model : DbObjs
    {
        [Required]
        public Brand Brand { get; set; }
    }

}
