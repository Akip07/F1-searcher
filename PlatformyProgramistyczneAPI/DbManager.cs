﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlatformyProgramistyczneAPI.F1Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyProgramistyczneAPI
{

    internal class DbManager
    {
        private DriversDatabase driversDatabase;
        private OpenF1Api api = new OpenF1Api();
        public DbManager()
        {

            driversDatabase = new DriversDatabase();
        }
        public void AddDriver(int driver_number = 0,string broadcast_name = "test",string full_name = "test",string name_acronym = "test",string team_name = "test",string team_colour = "test",string first_name = "test",string last_name = "test",string headshot_url = "test",string country_code = "test",int session_key = 1,int meeting_key = 1)
        {
            driversDatabase.Drivers.Add(new DriverDb()
            {
                driver_number = driver_number,
                broadcast_name = broadcast_name,
                full_name = full_name,
                name_acronym = name_acronym,
                team_name = team_name,
                team_colour = team_colour,
                first_name = first_name,
                last_name = last_name,
                headshot_url = headshot_url,
                country_code = country_code,
                session_key = session_key,
                meeting_key = meeting_key,

            });
            driversDatabase.SaveChanges();
        }

        public void AddDriver(Driver driver) 
        {
            DriverDb temp = new DriverDb();
            PropertyInfo[] properties = typeof(Driver).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(temp, property.GetValue(driver));
                
            }
            if(temp.headshot_url ==null )
            {
                string url = "https://stbannandale.syd.catholic.edu.au/wp-content/uploads/sites/19/2019/09/Person-Icon.jpg";
                var driver2 = driversDatabase.Drivers.FirstOrDefault(d => d.full_name==temp.full_name && d.headshot_url!=null && d.headshot_url!=url);
                if(driver2 != null)
                {
                    temp.headshot_url = driver2.headshot_url;
                }
                else
                {
                    temp.headshot_url = url;
                }
            if(temp.team_colour == null)
                {
                    string color = "darkgrey";
                     driver2 = driversDatabase.Drivers.FirstOrDefault(d => d.full_name == temp.full_name && d.team_colour != null && d.team_colour != color);
                    if (driver2 != null)
                    {
                        temp.team_colour = driver2.team_colour;
                    }
                    else
                    {
                        temp.team_colour = color;
                    }
                }
                if (temp.team_name == null)
                {
                    string fillerTeam = "   ";
                    driver2 = driversDatabase.Drivers.FirstOrDefault(d => d.full_name == temp.full_name && d.team_name != null && d.team_name != fillerTeam);
                    if (driver2 != null)
                    {
                        temp.team_name = driver2.team_name;
                    }
                    else
                    {
                        temp.team_colour = fillerTeam;
                    }
                }

            }
            driversDatabase.Drivers.Add(temp);
            driversDatabase.SaveChanges();
        }


        public void AddDriver(List<Driver> drivers)
        {
            foreach (Driver driver in drivers)
            {
                AddDriver(driver);
            }
        }


        public void ClearDrivers()
        {
            driversDatabase.Drivers.RemoveRange(driversDatabase.Drivers);
            driversDatabase.SaveChanges(true);
        }



        public List<DriverDb> GetDriversFromTeam(string team_name)
        {
            List<DriverDb> drivers = driversDatabase.Drivers.Where(d => d.team_name == team_name).ToList<DriverDb>();
            return drivers;
           
        }



        public void RemoveDriver(int id)
        {
            var driver = driversDatabase.Drivers.First(d => d.id == id);
            driversDatabase.Drivers.Remove(driver);
            driversDatabase.SaveChanges();
        }



        public void ReplaceDriversDbBySession(int key)
        {
            ClearDrivers();
            List<Driver> drivers = api.GetSessionDrivers(key).Result;
            
            AddDriver(drivers);
        }



        public void ReplaceDriversDbByTeam(string team)
        {
            ClearDrivers();
            List<Driver> drivers = api.GetTeamDrivers(team).Result;
            AddDriver(drivers);
        }
            

        public void PrintDrivers() 
        {
            List<DriverDb> drivers = driversDatabase.Drivers.ToList<DriverDb>();
            foreach (DriverDb driver in drivers)
            {
                Console.WriteLine(driver.ToString());
            }
        }
        public void AddSession(Session session)
        {
            SessionDb temp = new SessionDb();
            PropertyInfo[] properties = typeof(Session).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(temp, property.GetValue(session));
            }
            driversDatabase.Sessions.Add(temp);
            driversDatabase.SaveChanges();
        }
        public void AddSession(List<Session> sessions)
        {
            foreach (Session session in sessions)
            {
                AddSession(session);
            }
        }
        public void ClearSessions()
        {
            driversDatabase.Sessions.RemoveRange(driversDatabase.Sessions);
            driversDatabase.SaveChanges(true);
        }
        public void ReplaceSessionsDbByYear(int year)
        {
            ClearSessions();
            List<Session> sessions = api.GetSeasonRaces(year).Result;

            AddSession(sessions);

        }
        
        public void PrintSessions()
        {
            List<SessionDb> sessions = driversDatabase.Sessions.ToList<SessionDb>();
            foreach (SessionDb session in sessions)
            {
                Console.WriteLine(session.ToString());
            }
        }


        

        public void DriversFromSession(int key)
        {
            List<DriverDb> drivers = driversDatabase.Drivers.Where(d => d.session_key==key).ToList<DriverDb>();
            if(drivers.Count == 0)
            {
                List<Driver> temp = api.GetSessionDrivers(key).Result;
                AddDriver(temp);
                drivers = driversDatabase.Drivers.Where(d => d.session_key == key).ToList<DriverDb>();
            }
            
        }

        public bool CheckIfDriversEmpty()
        {
            DriverDb drivers = driversDatabase.Drivers.FirstOrDefault();
            return drivers==null? true: false;
        }


        
    }
}
