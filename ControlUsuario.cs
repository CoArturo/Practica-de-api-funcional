using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace Practica_de_api;

    public class ControlUsuario
    {
        private string filePath = "C:/Users/abela/source/repos/Programacion 2/Practica-de-api-master/Practica-de-api-master/bin/Debug/net6.0/usuario.json";

        public ControlUsuario(string jsonFilePath)
        {
            filePath = jsonFilePath;
        }

        public List<Models.UsuarioEstructura> CargarUsuarios()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Models.UsuarioEstructura>>(json);
            }
            return new List<Models.UsuarioEstructura>();
        }

        public List<Models.UsuarioEstructura> GetAllUsuarios()
        {
            List<Models.UsuarioEstructura> usuarios = new List<Models.UsuarioEstructura>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                usuarios = JsonConvert.DeserializeObject<List<Models.UsuarioEstructura>>(json);
            }

            return usuarios;
        }

        public void AddUsuario(Models.UsuarioEstructura usuario)
        {
            List<Models.UsuarioEstructura> usuarios = GetAllUsuarios();

            if (usuarios == null)
            {
                usuarios = new List<Models.UsuarioEstructura>();
            }

            if (usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario | u.Id == usuario.Id))
            {
                return;
            }

            usuarios.Add(usuario);

            string newJson = JsonConvert.SerializeObject(usuarios);
            File.WriteAllText(filePath, newJson);
        }
    }

