using _00_EntityFramework_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFramework_ClassLibrary.Services
{

    // CRUD = Create, Read, Update, Delete


    public class UserService
    {
        private SqlContext _context = new SqlContext();
        private AddressService _addressService = new AddressService(); 


        public void Create(User user) // Create
        {
            var _user = new UserEntity();
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Email = user.Email;
            _user.AddressId = _addressService.Create(
                new Address 
                { 
                    StreetName = user.StreetName, 
                    PostalCode = user.PostalCode,
                    City = user.City,
                }).Id;

            _context.Users.Add(_user);
            _context.SaveChanges();
        }

        public User Get(int id) // Read
        {
            var _user = _context.Users.Include(x => x.Address).Where(x => x.Id == id).FirstOrDefault();

            var user = new User
            {
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Email = _user.Email,
                StreetName = _user.Address.StreetName,
                PostalCode = _user.Address.PostalCode,
                City = _user.Address.City
            };

            return user;
        }

        public List<User> GetAll() // Read
        {
            var _users = _context.Users.Include(x => x.Address).ToList();

            var users = new List<User>();
            foreach (var _user in _users)
                users.Add(new User
                {
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Email = _user.Email,
                    StreetName = _user.Address.StreetName,
                    PostalCode = _user.Address.PostalCode,
                    City = _user.Address.City
                });

            return users;
        }

        public void Update(int id, User user) // Update
        {
            var _user = _context.Users.Find(id);
            if (_user != null)
            {
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Email = user.Email;

                _context.Update(_user);
                _context.SaveChanges();
            }

        }

        public void Delete(int id) // Delete
        {
            var _user = _context.Users.Find(id);
            if( _user != null )
            {
                _context.Remove(_user);
                _context.SaveChanges();
            }
        }
    }
}

/*
        return _context.Users.Include(x => x.Address).ToList();  
    
        SELECT
            u.Id,
            u.FirstName,
            u.LastName,
            u.Email,
            u.AddressId,
            a.Id,
            a.StreetName,
            a.PostalCode,
            a.City
        FROM Users u
        JOIN Addresses a ON a.Id == u.AddressId
*/