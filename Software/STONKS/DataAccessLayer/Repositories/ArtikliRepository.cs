﻿using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ArtikliRepository : Repository<Artikl>
    {

        public ArtikliRepository() : base(new STONKS_DB())
        {

        }

        //Author : Martin Friščić (all code)


        public override IQueryable<Artikl> GetAll()
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        select e;

            return query;
        }

        //gets all the articles ordered by name
        public  IQueryable<Artikl> GetAbecedno()
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        orderby e.naziv
                        select e;

            return query;
        }


        //gets all the articles ordered by price

        public IQueryable<Artikl> GetPoCijeni()
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        orderby e.jed_cijena
                        select e;

            return query;
        }

        //adds the article in database

        public override int Add(Artikl entity, bool save = true)
        {   
            //navigation property binding
            var vrstaArtikla = Context.VrsteArtikla.SingleOrDefault(v => v.id == entity.vrsta_artikla_id);

            var artikl = new Artikl
            {
                VrsteArtikla = vrstaArtikla,
                naziv = entity.naziv,
                sifra = entity.sifra,
                jed_cijena = entity.jed_cijena,
                pdv = entity.pdv,
                vrsta_artikla_id = entity.vrsta_artikla_id,
                barkod=entity.barkod,

            };

            Entities.Add(artikl);

            if (save)
            {
                return SaveChanges();
            }

            else return 0;

        }

        //the following methods GetByName, GetByType and GetBySifra get the articles that contain value of
        //forwarded parameter


        public IQueryable<Artikl> GetByName(string name)
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        where e.naziv.Contains(name)
                        select e;
            return query;
        }

        public IQueryable<Artikl> GetByType(string name)
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        where e.VrsteArtikla.naziv.Contains(name)
                        select e;
            return query;
        }

        public IQueryable<Artikl> GetBySifra(string sifra)
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        where e.sifra == sifra
                        select e;
            return query;
        }

        public IQueryable<Artikl> GetArtiklById(int id)
        {
            var query = from e in Entities.Include("VrsteArtikla").Include("StavkePrimke").Include("StavkeRacuna")
                        where e.id == id
                        select e;
            return query;
        }



        public override int Update(Artikl entity, bool save = true)
        {
            var artikl = Context.Artikli.SingleOrDefault(a => a.id == entity.id);
            artikl.id = entity.id;
            artikl.sifra = entity.sifra;
            artikl.naziv = entity.naziv;
            artikl.saldo = entity.saldo;
            artikl.jed_cijena = entity.jed_cijena;
            artikl.pdv = entity.pdv;
            artikl.vrsta_artikla_id = entity.vrsta_artikla_id;
            artikl.barkod = entity.barkod;
           /* artikl.StavkePrimke = entity.StavkePrimke;
            artikl.VrsteArtikla = entity.VrsteArtikla;
            artikl.StavkeRacuna = entity.StavkeRacuna;*/

            if (save)
                return SaveChanges();
            else
                return 0;

        }
    }
}
