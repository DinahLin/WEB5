using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web;
using Assignment2.EntityModels;
using Assignment2.Models;
using System.Linq;

namespace Assignment2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();
                // Map from Employee design model to EmployeeBaseViewModel.
                cfg.CreateMap<Employee, EmployeeBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();

                // Map from EmployeeAddViewModel to Employee design model.
                cfg.CreateMap<EmployeeAddViewModel, Employee>();
                cfg.CreateMap<TrackAddViewModel, Track>();
                cfg.ValidateInlineMaps = false;

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()
        public IEnumerable<EmployeeBaseViewModel> EmployeeGetAll()
        {
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBaseViewModel>>(ds.Employees);
        }

        public EmployeeBaseViewModel EmployeeGetById(int id)
        {
            // Attempt to fetch the object.
            var obj = ds.Employees.Find(id);

            // Return the result (or null if not found).
            return obj == null ? null : mapper.Map<Employee, EmployeeBaseViewModel>(obj);
        }

        

        public EmployeeBaseViewModel EmployeeAdd(EmployeeAddViewModel newEmployee)
        {
            // Attempt to add the new item.
            // Notice how we map the incoming data to the Employee design model class.
            var addedItem = ds.Employees.Add(mapper.Map<EmployeeAddViewModel, Employee>(newEmployee));
            ds.SaveChanges();

            // If successful, return the added item (mapped to a view model class).
            return addedItem == null ? null : mapper.Map<Employee, EmployeeBaseViewModel>(addedItem);
        }
        public EmployeeBaseViewModel EmployeeEditContactInfo(EmployeeEditContactViewModel employee)
        {
            // Attempt to fetch the object.
            var obj = ds.Employees.Find(employee.EmployeeId);
            if (obj == null)
            {
                // Customer was not found, return null.
                return null;
            }
            else
            {
                // Customer was found. Update the entity object
                // with the incoming values then save the changes.
                ds.Entry(obj).CurrentValues.SetValues(employee);
                ds.SaveChanges();
                // Prepare and return the object.
                return mapper.Map<Employee, EmployeeBaseViewModel>(obj);
            }
        }

        // Track
        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks);
        }

        public TrackBaseViewModel TrackGetById(int id)
        {
            // Attempt to fetch the object.
            var obj = ds.Tracks.Find(id);

            // Return the result (or null if not found).
            return obj == null ? null : mapper.Map<Track, TrackBaseViewModel>(obj);
        }
        public TrackBaseViewModel TrackAdd(TrackAddViewModel newTrack)
        {
            // Attempt to add the new item.
            // Notice how we map the incoming data to the Employee design model class.
            var addedItem = ds.Tracks.Add(mapper.Map<TrackAddViewModel,Track>(newTrack));
            ds.SaveChanges();

            // If successful, return the added item (mapped to a view model class).
            return addedItem == null ? null : mapper.Map<Track, TrackBaseViewModel>(addedItem);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllPop()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.Where(t => t.GenreId == 9).OrderByDescending(t =>t.Name ));
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllTop100Longest()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(
                ds.Tracks
                .OrderByDescending(t => t.Milliseconds)
                .Take(100)
                );
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllDeepPurple()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(
                ds.Tracks
                .Where(t => t.Composer.Contains("Jon Lord"))
                .OrderBy(t => t.TrackId)
                );
        }


    }
}