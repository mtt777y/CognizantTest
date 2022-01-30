using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CognizantTest.LoadedEntities;
using CognizantTest.DataEntities;
using NLog;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CognizantTest.Common
{
    public static class RecursiveParser
    {
        //parse data from file and wtite to db
        public static void Parse(DbSets dbsets, ILogger logger, string strdata)
        {
            List<Brand> newBrands = new();
            List<Model> newModels = new();

            List<IncEntity> data = JsonConvert.DeserializeObject<List<IncEntity>>(strdata);

            foreach (IncEntity storage in data)
            {
                Warehouse warehouse = new Warehouse(storage);
                dbsets.Set<Warehouse>().Add(warehouse);
                foreach (Vehicle vehicle in storage.Cars.Vehicles)
                {
                    vehicle.Warehouse = warehouse;
                    vehicle.FillVehicle<Brand>(newBrands);
                    vehicle.FillVehicle<Model>(newModels, newBrands);
                    dbsets.Set<Vehicle>().Add(vehicle);
                }
            }


            dbsets.Set<Brand>().AddRange(newBrands);
            dbsets.Set<Model>().AddRange(newModels);
            dbsets.SaveChanges();

            logger.Info("Load complete!");
        }

        //function for fill vehicle data
        //work with brands or models
        public static void FillVehicle<T>(this Vehicle vehicle, List<T> incList, List<Brand> secList = null) where T : DbObjs, new()
        {
            T findedEntity = null;

            PropertyInfo[] propsVeh = vehicle.GetType().GetProperties();
            PropertyInfo jsonVal = propsVeh.ToList().Find(f => f.Name == typeof(T).Name + "Json"); //get prop for read data from json
            PropertyInfo needVal = propsVeh.ToList().Find(f => f.Name == typeof(T).Name); //get prop for write data to sql

            findedEntity = incList.Find(f => f.Name == jsonVal.GetValue(vehicle).ToString());

            if (findedEntity == null)
            {
                findedEntity = new() { Name = jsonVal.GetValue(vehicle).ToString() };
                incList.Add(findedEntity);
            }

            if (secList != null) //fill brand in model
            {
                PropertyInfo[] propsEntity = findedEntity.GetType().GetProperties();
                PropertyInfo findPr = propsEntity.ToList().Find(f => f.Name == "Brand");
                findPr.SetValue(findedEntity, secList.Find(f => f.Name == vehicle.BrandJson));
            }

            
            needVal.SetValue(vehicle, findedEntity);
        }
    }
}
