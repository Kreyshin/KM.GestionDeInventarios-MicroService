﻿using Dapper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Infraestructura.Comunes
{
    public class Utilitarios
    {
        public static DynamicParameters GenerarParametros(object parametros)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            JObject OJson = JObject.Parse(JsonConvert.SerializeObject(parametros, Formatting.Indented));

            foreach (var item in OJson)
            {
                if (item.Key.Substring(0, 1) == "O")
                {
                  
                    var valor = JObject.Parse(JsonConvert.SerializeObject(item.Value, Formatting.Indented));
                    DbType type = DbType.String;
                    switch (valor.GetValue("type").ToString())
                    {
                        case "16":
                            type = DbType.String;
                            break;

                    }
                    dynamicParameters.Add($"@{item.Key}", dbType: type, direction: System.Data.ParameterDirection.Output, size: Convert.ToInt32(valor.GetValue("size").ToString()));
                }
                else
                {
                    var keyParam = item.Key;
                    var token = item.Value;

                    if( token.Type != JTokenType.Null)
                    {
                        if (keyParam.StartsWith("IID"))
                        {
                            dynamicParameters.Add($"@{keyParam}", value: token.Value<int>(), DbType.Int32, ParameterDirection.Input);
                        }
                        else if (keyParam.StartsWith("IB"))
                        {
                            dynamicParameters.Add($"@{keyParam}", value: token.Value<bool?>(), DbType.Boolean, ParameterDirection.Input);
                        }
                        else if (keyParam.StartsWith("IC"))
                        {
                            dynamicParameters.Add($"@{keyParam}", value: token.Value<string>(), DbType.String, ParameterDirection.Input);
                        }
                    }

                    

                }
            }

            return dynamicParameters;
        }
    }
}
