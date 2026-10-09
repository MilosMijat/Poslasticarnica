using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public class PrSs : IEntity
    {
        public int Id { get; set; }

        public Prodavac Prodavac { get; set; }
        public StrucnaSprema StrucnaSprema { get; set; }
        public int StepenSS { get; set; }
        public DateTime DatumSticanja { get; set; }

        public string TableName => "PrSS";

        public string Values =>
            $"{Prodavac.Id}, {StrucnaSprema.Id}, {StepenSS}, '{DatumSticanja:yyyy-MM-dd}'";

        public string Join =>
            "JOIN Prodavac p ON (p.idProdavac = PrSS.idProdavac) " +
            "JOIN Strucna_Sprema ss ON (ss.idStrucnaSprema = PrSS.idStrucnaSprema)";

        public string Set =>
            $"SET idProdavac = {Prodavac.Id}, idStrucnaSprema = {StrucnaSprema.Id}, stepenSS = {StepenSS}, datumSticanja = '{DatumSticanja:yyyy-MM-dd}'";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();

            while (reader.Read())
            {
                PrSs veza = new PrSs
                {
                    Id = 0,

                    Prodavac = new Prodavac
                    {
                        Id = (int)reader["idProdavac"],
                        Ime = (string)reader["ime"],
                        Prezime = (string)reader["prezime"]
                    },

                    StrucnaSprema = new StrucnaSprema
                    {
                        Id = (int)reader["idStrucnaSprema"],
                        Naziv = (string)reader["naziv"],
                        Trajanje = reader["trajanje"] == DBNull.Value ? 0 : (int)reader["trajanje"]
                    },

                    StepenSS = reader["stepenSS"] == DBNull.Value ? 0 : (int)reader["stepenSS"],
                    DatumSticanja = reader["datumSticanja"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["datumSticanja"]
                };

                lista.Add(veza);
            }

            return lista;
        }
    }
}
