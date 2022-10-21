﻿using System;
using System.Collections.Generic;
using System.Text;
using PM2_P1Tarea1_4.Models;
using System.Threading.Tasks;
using SQLite;


namespace PM2_P1Tarea1_4.Controller
{
    public class BaseDatos
    {

        readonly SQLiteAsyncConnection dbase;

        public BaseDatos(string path)
        {
            dbase = new SQLiteAsyncConnection(path);

            dbase.CreateTableAsync<Imagen>();
        }

        #region OperacionesImagen
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateImagen(Imagen img)
        {
            if (img.id != 0)
            {
                return dbase.UpdateAsync(img);
            }
            else
            {
                return dbase.InsertAsync(img);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Imagen>> getListImagen()
        {
            return dbase.Table<Imagen>().ToListAsync();
        }

        public Task<Imagen> getImagen(int id)
        {
            return dbase.Table<Imagen>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteImagen(Imagen img)
        {
            return dbase.DeleteAsync(img);
        }

        #endregion OperacionesImagen

    }
}
